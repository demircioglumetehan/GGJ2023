using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : Singleton<PlayerWrapper>
{
    public PlayerHealthController PlayerHealthController{get;private set;}
    public PlayerAttackController PlayerAttackController { get; private set; }
    public PlayerAnimationController PlayerAnimationController { get; private set; }
    public PlayerExperienceSystem PlayerExperienceSystem { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public CharacterController CharacterController { get; private set; }
    protected override void Awake()
    {
        PlayerHealthController = GetComponent<PlayerHealthController>();
        PlayerAttackController = GetComponent<PlayerAttackController>();
        PlayerAnimationController = GetComponent<PlayerAnimationController>();
        PlayerExperienceSystem = GetComponent<PlayerExperienceSystem>();
        PlayerMovement = GetComponent<PlayerMovement>();
        CharacterController = GetComponent<CharacterController>();
        base.Awake();   
    }
}
