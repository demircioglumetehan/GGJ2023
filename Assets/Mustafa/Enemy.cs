
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField] protected int damageAmount=3;
    [SerializeField] protected float health=8;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected int xp = 5;
    private Animator enemyAnimator;
    private void Awake()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        FollowPlayer();
    }
    public void HitPlayer()
    {
        PlayerWrapper.instance.PlayerHealthController.Health -= damageAmount;
        enemyAnimator.SetBool("Attack", true);
        StartCoroutine(WaitForAttackFinishCor());

    }

    private IEnumerator WaitForAttackFinishCor()
    {
        yield return new WaitForSeconds(1f);
        enemyAnimator.SetBool("Attack", false);
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
        PlayerWrapper.instance.PlayerExperienceSystem.AddXP(xp);
        this.gameObject.SetActive(false);
    }


    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, PlayerWrapper.instance.transform.position, speed * Time.deltaTime);
        enemyAnimator.SetFloat("speed", 1f);
        transform.LookAt(new Vector3( PlayerWrapper.instance.transform.position.x,transform.position.y, PlayerWrapper.instance.transform.position.z));
    }
}
