using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotowGroundInteractPoint : MonoBehaviour
{
    [SerializeField] private float damageAmount = 5f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<IDamageable>(out var damagable))
        {
            damagable.TakeDamage(damageAmount);
        }
    }
}
