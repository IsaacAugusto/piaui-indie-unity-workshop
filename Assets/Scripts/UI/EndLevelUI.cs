using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    [SerializeField] private Text _points;
    
    public void LoadNextLevel()
    {
        var current = SceneManager.GetActiveScene().buildIndex;
        if (current < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(current + 1);
        }
    }

    public void ReloadLevel()
    {
        var current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowUI(int points)
    {
        gameObject.SetActive(true);
        _points.text = $"{points}";
    }

    public void HideUI()
    {
        gameObject.SetActive(false);
    }
}
