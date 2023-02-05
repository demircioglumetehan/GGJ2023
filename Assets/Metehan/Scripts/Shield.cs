using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.PushTowards(this);
            enemy.TakeDamage(2f);
        }
        if (other.TryGetComponent<Monster>(out var monster))
        {
            monster.PushTowards(this);
            monster.TakeDamage(2f);
        }
    }
}
