using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public static class SceneLoaderParams
{
    public static string mainScene;
    public static float timeSet;
    public static float beforeTimeFinish;

}

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textTimerMinute;
    public TextMeshProUGUI textTimerSeconds;

    [Header("Timer config")]
    [SerializeField] public bool isMainLevel;
    [SerializeField] public float seconds;
    [SerializeField] public float beforeTimeFinish;

    private float _setTime;
    string scene;
    bool secondsPassed;


    private void Start()
    {
     scene = SceneManager.GetActiveScene().name;
        if (isMainLevel)
        {
            SceneLoaderParams.mainScene = scene;
            SceneLoaderParams.beforeTimeFinish = beforeTimeFinish;
            _setTime = seconds;
        } else
        {
            _setTime = SceneLoaderParams.timeSet;
        }
    }

    void Update()
    {

        _setTime -= Time.deltaTime;

        if (isMainLevel)
            SceneLoaderParams.timeSet = _setTime;

        textTimerMinute.text = TimeSpan.FromSeconds(_setTime).Minutes.ToString("f0").PadLeft(2, '0');
        textTimerSeconds.text = TimeSpan.FromSeconds(_setTime).Seconds.ToString("f0").PadLeft(2,'0');

        if (_setTime <= SceneLoaderParams.beforeTimeFinish && !secondsPassed)
        {
            secondsPassed = true;
            Debug.Log("faltan " + SceneLoaderParams.beforeTimeFinish + " segundos");
        }

        if (_setTime <= 0)
        SceneManager.LoadScene(SceneLoaderParams.mainScene);


        //textoTimer.text = "" + timer.ToString("f0");
    }
}
