<<<<<<< Updated upstream
=======
using System;
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int damageAmount=3;
    [SerializeField] protected int health=8;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected int xp = 5;
    private void Update()
    {
        FollowPlayer();
    }
    public void HitPlayer()
    {
        Player.instance.Health -= damageAmount;
        
    }
<<<<<<< Updated upstream
=======
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            OnDestroyEnemyObject();
            ExperienceSystem.instance.AddXP(xp);
        }

    }

    private void OnDestroyEnemyObject()
    {
        this.gameObject.SetActive(false);
    }
>>>>>>> Stashed changes

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.instance.transform.position, speed * Time.deltaTime);
    }
}
