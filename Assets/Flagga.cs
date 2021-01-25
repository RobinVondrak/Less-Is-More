using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flagga : MonoBehaviour
{
    public GameObject stars;
    bool hissad = false;
    void HissaFlagga()
    {
        if (!hissad)
        {
            hissad = true; //disabla collider ist?
            Transform flagga = transform.Find("FlaggaFlagg");
            Transform flaggaPos = transform.Find("TopOfFlaggaPos");
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
