using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float coolDownTimeForAttack=.5f;
    private CharacterController characterController;
    int lastcombatinteger = 0;
    float latestAttackTime;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (characterController.velocity.magnitude > 0.2f)
        {
            playerAnimator.SetFloat("speed", 1f);
        }
        else
        {
            playerAnimator.SetFloat("speed", 0f);
        }
        if (Input.GetMouseButtonDown(0)|| Input.GetKey(KeyCode.Space))
        {
            if(Time.time - latestAttackTime> coolDownTimeForAttack)
            {
                latestAttackTime = Time.time;
                lastcombatinteger++;
                if (lastcombatinteger > 4)
                    lastcombatinteger = 1;

                playerAnimator.SetTrigger("Attack" + lastcombatinteger.ToString());
            }
         
        }
    }
}
