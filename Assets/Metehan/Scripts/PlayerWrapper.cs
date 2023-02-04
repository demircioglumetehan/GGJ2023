using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : Singleton<PlayerWrapper>
{
    public PlayerHealthController PlayerHealthController{get;private set;}
    public PlayerAttackController PlayerAttackController { get; private set; }
    public PlayerAnimationController PlayerAnimationController { get; private set; }
    protected override void Awake()
    {
        PlayerHealthController = GetComponent<PlayerHealthController>();
        PlayerAttackController = GetComponent<PlayerAttackController>();
        PlayerAnimationController = GetComponent<PlayerAnimationController>();
        base.Awake();   
    }
}
