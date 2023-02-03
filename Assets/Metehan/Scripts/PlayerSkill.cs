using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField] protected SkillFeatures skillFeature;
    public virtual void ActivateSkill()
    {

    } 
}
