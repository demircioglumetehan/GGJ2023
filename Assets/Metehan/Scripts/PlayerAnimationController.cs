using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float coolDownTimeForAttack=.5f;
    private CharacterController characterController;

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
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetBool("Attack" ,true);
          
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimator.SetBool("Attack", false);

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("Run", false);
        }
    }
    public void UpdateWalkAnim(float speed)
    {
        playerAnimator.SetFloat("speed", speed);
    }
  
    public void EnableRunAnim()
    {
        playerAnimator.SetBool("Run", true);
    }
    public void DisableRunAnim()
    {
        playerAnimator.SetBool("Run", false);
    }
    public void EnableAttackAnim()
    {
        playerAnimator.SetBool("Attack", true);

    }
    public void DisableAttackAnim()
    {
        playerAnimator.SetBool("Attack", false);
    }


}
