using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver => _isGameOver;
    [SerializeField] private bool _isGameOver;


    private int _lastLevel;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel()
    {
        _lastLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    
    public void LoadPrevLevel()
    {
        _lastLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(_lastLevel);
    }
    
}
