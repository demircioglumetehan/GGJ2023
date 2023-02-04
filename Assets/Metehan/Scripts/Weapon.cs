using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponFeatures weaponFeature;
    public WeaponFeatures WeaponFeature
    {
        get { return weaponFeature; }
        set { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out var enemy))
        {
            PlayerWrapper.instance.PlayerAttackController.OnPlayerAttackToEnemy(enemy);
        }
    }
}