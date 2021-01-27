using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleSlime : MonoBehaviour
{
    Transform slimeObj;
    Vector3[] positions;
    int posIndex = 0;
    bool goingLeft = false;
    int currentHealth = 2;
    public GameObject slime;
    private void Start()
    {
        slimeObj = transform.Find("SlimeObj");
        positions = new Vector3[transform.childCount - 1];
        int n = 0;
        foreach (Transform g in GetComponentsInChildren<Transform>())
        {
            if (g.name == "Pos")
            {
                positions[n] = g.position;
                n++;
            }
        }
        slimeObj.position = positions[0];
        StartCoroutine(Delay(1f));
    }
    IEnumerator Delay(float maxDelay)
    {
        yield return new WaitForSeconds(maxDelay);
        NextPoint();
    }
    void NextPoint()
    {
        slimeObj.transform.DOMove(positions[posIndex], 0.2f).OnComplete(NextPos).SetEase(Ease.Linear);
    }
    void NextPos()
    {
        if (goingLeft)
        {
            posIndex -= 1;
            if (posIndex <= 0)
            {
                posIndex = 0;
                goingLeft = false;
            }
        }
        else
        {
            posIndex += 1;
            if (posIndex >= positions.Length - 1)
            {
                posIndex = positions.Length - 1;
                goingLeft = true;
            }
        }
        NextPoint();
    }

    public void TakeDmg()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
            Death();
    }
    void Death()
    {
        if (slime != null)
            Instantiate(slime, slimeObj.position, slime.transform.rotation);

        Destroy(gameObject);
    }
}
