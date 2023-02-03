using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TurningPlayer : PlayerSkill
{
    private void Start()
    {
        ActivateSkill();
    }
    public override void ActivateSkill()
    {
        var value = skillFeature.Value;
        transform.DOLocalRotate(new Vector3(0, 360f, 0f), 2f, RotateMode.FastBeyond360).SetRelative(true).SetLoops(Mathf.RoundToInt(value), LoopType.Restart).SetEase(Ease.Linear);
    }
}
