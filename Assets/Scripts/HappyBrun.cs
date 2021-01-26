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
    bool hasApple = false;
    AppleManager appleManager;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        appleManager = player.GetComponent<AppleManager>();
    }

    void Update()
    {
        if (enterd && Input.GetKeyDown(KeyCode.N))
            NextText();

        if (enterd && Input.GetKeyDown(KeyCode.G) && !hasApple)
        {
            hasApple = true;
            appleManager.GiveApple();
        }
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
        if (n == sentences.Length)
            return;

        text.text = sentences[n];
        n++;
    }
}
