using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Points => _points;
    public static bool IsRunning { get; private set; }
    private int _points;

    private void Start()
    {
        StartLevel();
    }

    public void CollectPoint()
    {
        _points++;
    }

    public void StartLevel()
    {
        Debug.Log("Start Level");
        IsRunning = true;
    }

    public void EndLevel()
    {
        Debug.Log($"End Level with {_points} points!");
        IsRunning = false;
    }
}
