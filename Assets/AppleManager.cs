using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    public int ApplesToGive;
    public float speedPerAppleLoss = 0;
    public int givenApples;
    public float maxBonusSpeed = 10;

    private void Start()
    {
        if (speedPerAppleLoss == 0)
            speedPerAppleLoss = maxBonusSpeed / ApplesToGive;

        givenApples = 0;
    }

    public float charachterAppleLossBoost()
    {
        return speedPerAppleLoss * givenApples;
    }

    public void GiveApple()
    {
        givenApples += 1;
        Debug.Log("Gave Apple, increaseSpeed");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            GiveApple();
    }
}
