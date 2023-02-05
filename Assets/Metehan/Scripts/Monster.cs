using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour,IDamageable
{
    private Animator monsterAnimator;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float damageAmount = 5f;
    [SerializeField] protected float attackDistance = 1f;
    [SerializeField] protected float initialHealth = 200f;

    internal void PushTowards(Shield shield)
    {
        var forcedirection = (shield.transform.position - transform.forward).normalized;
        transform.DOMove(transform.position + 2f * forcedirection, .2f);
    }

    [SerializeField] protected float currentHealth ;
    [SerializeField] protected Image healthBarImage ;
    bool fightStarted = false;
    bool following = false;
    bool attacking = false;
    bool animatingattack = false;
    private Rigidbody monsterRigidbody;
    private void OnEnable()
    {
        GateTeleporter.OnPlayerTeleportedToArena += StartFight;
    }

    

    private void OnDisable()
    {
        GateTeleporter.OnPlayerTeleportedToArena -= StartFight;
    }
    private void StartFight()
    {
        currentHealth = initialHealth;
        fightStarted = true;
        setHealthBarImage();
    }

    private void setHealthBarImage()
    {
        healthBarImage.fillAmount = currentHealth / initialHealth;
    }

    private void Awake()
    {
        monsterAnimator = GetComponent<Animator>();
        monsterRigidbody = GetComponent<Rigidbody>();


    }
    private void Update()
    {
       
        if (!fightStarted)
            return;
        CheckDistance();
        FollowPlayer();
    }

    private void CheckDistance()
    {
        if (animatingattack)
            return;
        if (Vector3.Distance(transform.position, PlayerWrapper.instance.transform.position) < attackDistance)
        {
            attacking = true;
            AttackToPlayer();
        }
        else
        {
            FollowPlayer();
            following = true;
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, PlayerWrapper.instance.transform.position- 2f* transform.forward, speed * Time.deltaTime);
        transform.LookAt(new Vector3(PlayerWrapper.instance.transform.position.x, transform.position.y, PlayerWrapper.instance.transform.position.z));

        monsterAnimator.SetBool("Walk", true);
    }

    private void AttackToPlayer()
    {
        if (animatingattack)
            return;
        animatingattack = true;
        StartCoroutine(CoolDownTimerCor());
        PlayerWrapper.instance.PlayerHealthController.Health -= damageAmount;
        monsterAnimator.SetTrigger("Attack");
        monsterAnimator.SetBool("Walk", false);
    }

    private IEnumerator CoolDownTimerCor()
    {
        yield return new WaitForSeconds(1f);
        animatingattack = false;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDestroyMonster();
        }
        setHealthBarImage();
    }

    private void OnDestroyMonster()
    {
        Debug.Log("Monster Destroyed");
        monsterAnimator.SetTrigger("Dead");
        Invoke("DisappearMonster", .5f);
      
    }
    private void DisappearMonster()
    {
        this.gameObject.SetActive(false);
    }
}
