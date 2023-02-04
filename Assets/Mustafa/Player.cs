using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public int Health=100;

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
