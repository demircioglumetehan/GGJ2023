using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Molotow : MonoBehaviour
{
    [SerializeField] private GameObject bottleObject;
    [SerializeField] private GameObject groundObject;
    [SerializeField] private float activationTimeOnGround = 2f;

    public void ThrowMolotow(Vector3 molotowEndPosition)
    {
        groundObject.SetActive(false);
        bottleObject.SetActive(true);
        transform.DOJump(molotowEndPosition, 1, 1, .5f).OnComplete(() =>
        {
            groundObject.SetActive(true);
            bottleObject.SetActive(false);
            StartCoroutine(StartActivationTimerCor());
        });
    }

    private IEnumerator StartActivationTimerCor()
    {
        yield return new WaitForSeconds(activationTimeOnGround);
        groundObject.SetActive(false);
        bottleObject.SetActive(false);
    }
}
