using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TurningPlayer : PlayerSkill
{
    [SerializeField] private float turnSpeed;
   
    [SerializeField] private float coolDownTime=2f;
    bool canUse = true;
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
        if (!canUse)
            return;
        canUse = false;
        Audiomanager.instance?.PlayTurnSound();
        var value = skillFeature.Value;
        PlayerWrapper.instance.PlayerAttackController.ActivateTurning();
        transform.DOLocalRotate(new Vector3(0, 360f, 0f), 1f/ turnSpeed, RotateMode.FastBeyond360).SetRelative(true).SetLoops(32, LoopType.Restart).SetEase(Ease.Linear).OnComplete(() =>
        {
            PlayerWrapper.instance.PlayerAttackController.DeactivateTurning();
        });
        StartCoroutine(StartCoolDownTimerCor());
    }

    private IEnumerator StartCoolDownTimerCor()
    {
        yield return new WaitForSeconds(coolDownTime);
        canUse = true;
    }
}
