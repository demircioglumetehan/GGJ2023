using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float initialHealth = 100;

    [SerializeField] private Image currentHealthFillingImage;
    public float Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value <= 0)
            {
                OnPlayerDied();
            }
            currentHealth = value;
            UpdateCurrentHealthBar();
        }
    }
    private void Start()
    {
        currentHealth = initialHealth;
    }
    private void OnPlayerDied()
    {
        Debug.Log("Player Died");
    }


    private void OnCollisionEnter(Collision collision)
    {
        var interactible = collision.gameObject.GetComponent<Enemy>();
        if (interactible != null)
        {
            interactible.HitPlayer();
            //print("OnCollisionEnter player health: " + Health);
           
        }
    }

    private void UpdateCurrentHealthBar()
    {
        currentHealthFillingImage.fillAmount = (currentHealth / initialHealth);
        //print("fill amount: " + currentHealthFillingImage.fillAmount);
    }

   /* public void TakeDamage(float damageAmount)
    {
        health -=(int) damageAmount;

        UpdateCurrentHealthBar();
        if (health <= 0)
        {
            OnDestroyStone();
        }
    }*/
}
