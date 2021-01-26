using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBody : MonoBehaviour
{
    SimpleSlime simpleSlime;

    private void Awake()
    {
        simpleSlime = transform.parent.GetComponent<SimpleSlime>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHead"))
            simpleSlime.TakeDmg();
    }
}
