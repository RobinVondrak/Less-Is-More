using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappyBrun : MonoBehaviour
{
    public TextMeshPro text;
    GameObject player;
    public string[] sentences;
    int n;
    bool enterd = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (enterd && Input.GetKeyDown(KeyCode.N))
            NextText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != player)
            return;

        enterd = true;
        NextText();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
            enterd = false;
    }

    void NextText()
    {
        text.text = sentences[n];
        n++;
    }
}
