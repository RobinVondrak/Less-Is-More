using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleManager : MonoBehaviour
{
    public HappyBrun[] villagers;
    int applesGiven;
    int maxApples;
    public float maxSpeed;
    float speedPerAppleLoss;
    public TextMeshProUGUI text;

    void Start()
    {
        var villagers = GameObject.FindGameObjectsWithTag("Villager");
        this.villagers = new HappyBrun[villagers.Length];
        int n = 0;
        foreach (GameObject vill in villagers)
        {
            this.villagers[n] = vill.GetComponent<HappyBrun>();
            n++;
        }
        speedPerAppleLoss = maxSpeed / n;
        applesGiven = 0;
        maxApples = n;
        text.text = ($"{applesGiven}/{maxApples}");
    }
    public void GaveApple()
    {
        applesGiven += 1;
        if (applesGiven == maxApples)
            Debug.Log("Victory");
    }

    public float charachterAppleLossBoost()
    {
        return speedPerAppleLoss * applesGiven;
    }

    public void GiveApple()
    {
        applesGiven += 1;
        text.text = ($"{applesGiven}/{maxApples}");
    }
}
