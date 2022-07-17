using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
     [SerializeField] public float timer = 0;

    public TextMeshProUGUI textTimerMinute;
    public TextMeshProUGUI textTimerSeconds;

    string scene;



    private void Start()
    {
     scene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        textTimerMinute.text = TimeSpan.FromSeconds(timer).Minutes.ToString("f0").PadLeft(2, '0');
        textTimerSeconds.text = TimeSpan.FromSeconds(timer).Seconds.ToString("f0").PadLeft(2,'0');

        if (timer <= 3)
            Debug.Log("faltan 3 segundos");

        if (timer <= 0)
        SceneManager.LoadScene(scene);


        //textoTimer.text = "" + timer.ToString("f0");
    }
}
