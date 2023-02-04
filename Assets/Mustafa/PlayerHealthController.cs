using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private int health=100;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value <= 0)
            {
                OnPlayerDied();
            }
            health = value;
        }
    }

    private void OnPlayerDied()
    {
        Debug.Log("Player Died");
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactible = other.GetComponent<Enemy>();
        if (interactible != null)
        {
            interactible.HitPlayer();
            print("player health: " + Health);
        }
    }

}
