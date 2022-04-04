using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    [SerializeField] private GameObject[] form;

    public bool swapNow;
    private bool isCube = true;
    private void Start()
    {
        form[0].SetActive(isCube);
        form[1].SetActive(!isCube);
    }

    private void Update()
    {
        if (swapNow)
        {
            Swap();
        }
    }

    private void LateUpdate()
    {
        swapNow = false;
    }

    private void Swap()
    {
        isCube = !isCube;
        form[0].SetActive(isCube);
        form[1].SetActive(!isCube);
    }
}
