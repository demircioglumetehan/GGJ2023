using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShieldSkill : PlayerSkill
{
    [SerializeField] private List<GameObject> Shields;
    [SerializeField] private float coolDownTime = 2f;
    [SerializeField] private float activationTime = 5f;
    [SerializeField] private float turnSpeed=1f;

    bool canUse = true;
    private void Start()
    {
        EnableShields(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        EnableShields(true);
        transform.DOKill();
        var value = skillFeature.Value;
        PlayerWrapper.instance.PlayerAttackController.ActivateTurningShield();
        transform.DOLocalRotate(new Vector3(0, 360f, 0f), 1f / turnSpeed, RotateMode.FastBeyond360).SetRelative(true).SetLoops(Mathf.RoundToInt(activationTime), LoopType.Restart).SetEase(Ease.Linear).OnComplete(() =>
        {
            PlayerWrapper.instance.PlayerAttackController.DeactivateTurningShield();
            EnableShields(false);
        });
        StartCoroutine(StartCoolDownTimerCor());
    }

    private void EnableShields(bool enable)
    {
        foreach (var shield in Shields)
        {
            shield.SetActive(enable);
        }
    }

    private IEnumerator StartCoolDownTimerCor()
    {
        yield return new WaitForSeconds(coolDownTime + activationTime);
        canUse = true;
    }

}
