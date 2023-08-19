using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LevelManager.IsRunning && other.CompareTag("Player"))
        {
            _levelManager.EndLevel();
        }
    }
}
