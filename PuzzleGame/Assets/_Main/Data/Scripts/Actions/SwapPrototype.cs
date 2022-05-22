using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPrototype : MonoBehaviour
{

    [SerializeField] private GameObject nextForm, previusForm;

    public void ChangeNextForm()
    {
        Instantiate(nextForm, transform);
        Object.Destroy(this.gameObject);
    }
    public void ChangePreviusForm()
    {
        Instantiate(previusForm, transform);
        Object.Destroy(this.gameObject);
    }

}
