using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "SurvivorMode/SkillFeature", order = 1)]
public class SkillFeatures : ScriptableObject
{

    public string Explanation;
    public Sprite BuffIcon;
    public int Level;
    [SerializeField] private List<float> Values;

    public float Value => Values[Level - 1];

    public int MaxLevel => Values.Count;
    public bool IsMaxLevel => MaxLevel == Level;
}
