using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private void OnEnable()
    {
        LevelManager.OnLevelStart.AddListener(SpawnPlayer);
    }

    private void OnDisable()
    {
        LevelManager.OnLevelStart.RemoveListener(SpawnPlayer);
    }

    private void SpawnPlayer()
    {
        var playerT = Instantiate(_player, transform.position, quaternion.identity).transform;
        FindObjectOfType<CameraFollow>().SetTarget(playerT);
    }
}
