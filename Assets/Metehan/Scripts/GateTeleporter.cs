using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTeleporter : MonoBehaviour
{
    public static Action OnPlayerTeleportedToArena;
    [SerializeField] private Transform teleportPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayerToArena();

        }
    }
   

    private void TeleportPlayerToArena()
    {
        PlayerWrapper.instance.PlayerMovement.enabled = false;
        PlayerWrapper.instance.CharacterController.enabled = false;
        PlayerWrapper.instance.transform.position = teleportPoint.transform.position;
        PlayerWrapper.instance.PlayerMovement.enabled = true;
        PlayerWrapper.instance.CharacterController.enabled = true;
        OnPlayerTeleportedToArena?.Invoke();
    }
}
