using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    bool attacking = false;
    bool turning = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            PlayerWrapper.instance.PlayerAnimationController.EnableAttackAnim();
            attacking = true;

        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            PlayerWrapper.instance.PlayerAnimationController.DisableAttackAnim();
            attacking = false;

        }
    }

    public void ActivateTurning()
    {
        turning = true;
    }
    public void DeactivateTurning()
    {
        turning = false;
    }
    public void OnPlayerAttackToEnemy(IDamageable damageableobject)
    {
        if (turning)
        {
            damageableobject.TakeDamage(currentWeapon.WeaponFeature.hitDamage*2f);

        }
        if (attacking)
        {
            damageableobject.TakeDamage(currentWeapon.WeaponFeature.hitDamage);
        }
            
    }

   
}
