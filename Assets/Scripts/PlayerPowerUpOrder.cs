using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpOrder : MonoBehaviour
{
    public MonoBehaviour[] powerUps;

    int maxHealth = 3;
    public int n = 0;

    private void Start()
    {
        if (powerUps.Length == 0)
            powerUps = new MonoBehaviour[maxHealth];

        DeactivateAll();
    }

    void DeactivateAll()
    {
        foreach (MonoBehaviour mono in powerUps)
            mono.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ActivateNext();
    }

    private void ActivateNext()
    {
        if (n == maxHealth)
        {
            print("Death");
            return;
        }

        powerUps[n].enabled = true;
        n++;
    }
}
