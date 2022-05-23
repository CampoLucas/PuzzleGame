using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdmin : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Nivel_tutorial();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Nivel_1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Nivel_2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Nivel_3();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Nivel_4();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Nivel_5();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Nivel_6();
        }
    }

    private void Nivel_tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void Nivel_1()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void Nivel_2()
    {
        SceneManager.LoadScene("Level 2");
    }

    private void Nivel_3()
    {
        SceneManager.LoadScene("Level 3");
    }

    private void Nivel_4()
    {
        SceneManager.LoadScene("Level 4");
    }

    private void Nivel_5()
    {
        SceneManager.LoadScene("Level 5");
    }

    private void Nivel_6()
    {
        SceneManager.LoadScene("Level 6");
    }
}
