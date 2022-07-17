using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
     [SerializeField] public float seconds;

    public TextMeshProUGUI textTimerMinute;
    public TextMeshProUGUI textTimerSeconds;

    string scene;

    bool threeSecondsPassed;

    private void Start()
    {
     scene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        seconds -= Time.deltaTime * 10;

        textTimerMinute.text = TimeSpan.FromSeconds(seconds).Minutes.ToString("f0").PadLeft(2, '0');
        textTimerSeconds.text = TimeSpan.FromSeconds(seconds).Seconds.ToString("f0").PadLeft(2,'0');

        if (seconds <= 3 && !threeSecondsPassed)
        {
            threeSecondsPassed = true;
            Debug.Log("faltan 3 segundos");
        }

        if (seconds <= 0)
        SceneManager.LoadScene(scene);


        //textoTimer.text = "" + timer.ToString("f0");
    }
}
