using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int damageAmount=3;
    [SerializeField] protected int health=8;
    [SerializeField] protected float speed = 5f;
    private void Update()
    {
        FollowPlayer();
    }
    public void HitPlayer()
    {
        Player.instance.Health -= damageAmount;
        
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.instance.transform.position, speed * Time.deltaTime);
    }
}
