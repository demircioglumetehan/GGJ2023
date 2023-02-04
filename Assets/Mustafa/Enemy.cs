using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int damageAmount=3;
    [SerializeField] protected float health=8;
    [SerializeField] protected float speed = 5f;
    private void Update()
    {
        FollowPlayer();
    }
    public void HitPlayer()
    {
        PlayerWrapper.instance.PlayerHealthController.Health -= damageAmount;
        
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            OnDestroyEnemyObject();
        }

    }

    private void OnDestroyEnemyObject()
    {
        this.gameObject.SetActive(false);
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, PlayerWrapper.instance.transform.position, speed * Time.deltaTime);
    }
}
