using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour,IDamageable
{
    public static Action OnStoneDestroyed;
    [SerializeField] private float initialhealth;
    private float currenthealth;
    private void Start()
    {
        currenthealth = initialhealth;
    }
    public void TakeDamage(float damageAmount)
    {
        currenthealth -= damageAmount;
        
        UpdateCurrentHealthBar();
        if (currenthealth <= 0)
        {
            OnDestroyStone();
        }
    }

    private void OnDestroyStone()
    {
        OnStoneDestroyed?.Invoke();
        this.gameObject.SetActive(false);
    }

    private void UpdateCurrentHealthBar()
    {
        currentHealthFillingImage.fillAmount = (currenthealth / initialhealth);
    }

    [SerializeField] private Image currentHealthFillingImage;
}
