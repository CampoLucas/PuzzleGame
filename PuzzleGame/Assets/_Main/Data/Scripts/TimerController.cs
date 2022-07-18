using UnityEngine;
using TMPro;
using System;
using UnityEngine.Serialization;

public class TimerController : MonoBehaviour
{
    [FormerlySerializedAs("seconds")] [SerializeField] private float _time;
    private float _currentTime;
    private float _minutes;
    private float _seconds;
    

    [SerializeField] private TMP_Text _timeText;

    private void Start()
    { 
        _currentTime = _time;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime * 10;

        DisplayTime(_currentTime);
        
        if (_currentTime <= _time / 2)
            _timeText.color = Color.yellow;
        
        if (_currentTime <= _time / 6)
            _timeText.color = Color.red;

        if (_currentTime <= 0)
            GameManager.instance.ResetLevel();

    }

    void DisplayTime(float currentTime)
    {
        currentTime -= Time.deltaTime * 10;
        
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}

