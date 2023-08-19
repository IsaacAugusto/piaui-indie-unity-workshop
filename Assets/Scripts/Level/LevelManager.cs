using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int Points => _points;
    public static bool IsRunning { get; private set; }
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelEnd = new UnityEvent();
    [SerializeField] private EndLevelUI _endUI;
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
        _endUI.HideUI();
        Debug.Log("Start Level");
        IsRunning = true;
        OnLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        _endUI.ShowUI(_points);
        Debug.Log($"End Level with {_points} points!");
        IsRunning = false;
        OnLevelEnd?.Invoke();
    }
}
