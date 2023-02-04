using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TurningPlayer : PlayerSkill
{
    [SerializeField] private float turnSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ActivateSkill();
        }
    }
    [ContextMenu("ActivateSkill ")]
    public override void ActivateSkill()
    {
        var value = skillFeature.Value;
        transform.DOLocalRotate(new Vector3(0, 360f, 0f), 1f/ turnSpeed, RotateMode.FastBeyond360).SetRelative(true).SetLoops(Mathf.RoundToInt(value), LoopType.Restart).SetEase(Ease.Linear);
    }
}
