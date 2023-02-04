using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    [SerializeField] private GameObject RestrictionObject;
    [SerializeField] private GameObject GateObject;

    private void OnEnable()
    {
        Stone.OnStoneDestroyed += EnableGate;
    }
    private void Start()
    {
        DisableGate();
    }

    private void DisableGate()
    {
        GateObject.SetActive(false);
        RestrictionObject.SetActive(true);
    }

    private void OnDisable()
    {
        Stone.OnStoneDestroyed += EnableGate;
    }
    private void EnableGate()
    {
        GateObject.SetActive(true);
        RestrictionObject.SetActive(false);
    }

}
