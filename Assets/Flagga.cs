using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flagga : MonoBehaviour
{
    public GameObject stars;
    private Transform spawn;
    bool hissad = false;
    private void Start()
    {
        spawn = GameObject.Find("Out of bounds").transform.Find("Spawn");
    }
    void HissaFlagga()
    {
        if (!hissad)
        {
            hissad = true; //disabla collider ist?
            Transform flagga = transform.Find("FlaggaFlagg");
            Transform flaggaPos = transform.Find("TopOfFlaggaPos");
            spawn.transform.position = flaggaPos.position;
            flagga.DOMove(flaggaPos.position, 1f).OnComplete(SkapaFlagga);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            HissaFlagga();
    }
    void SkapaFlagga()
    {
        Transform flaggaPos = transform.Find("TopOfFlaggaPos");
        GameObject star = Instantiate(stars, flaggaPos.transform.position + (Vector3.up * 0.8f), stars.transform.rotation);
    }
}
