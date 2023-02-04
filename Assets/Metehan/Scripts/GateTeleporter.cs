using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTeleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerWrapper>(out var player))
        {
            TeleportPlayerToArena(player);

        }
    }

    private void TeleportPlayerToArena(PlayerWrapper player)
    {
        player.transform.position = teleportPoint.transform.position;
    }
}
