using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
=======

    public PlayerHealthController PlayerHealthController{get;private set;}
    public PlayerAttackController PlayerAttackController { get; private set; }
    public PlayerAnimationController PlayerAnimationController { get; private set; }
    protected override void Awake()
>>>>>>> Stashed changes
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
