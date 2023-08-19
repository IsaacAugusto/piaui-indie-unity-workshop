using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _levelManager.CollectPoint();
        Destroy(gameObject);
    }
}
