using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPrototype : MonoBehaviour
{

    [SerializeField] private Player nextForm, previusForm;

    public void ChangeNextForm()
    {
        Player O = Instantiate(nextForm, transform.parent);
        O.transform.position = transform.position;
        Object.Destroy(this.gameObject);
    }
    public void ChangePreviusForm()
    {
        Player O = Instantiate(previusForm, transform.parent);
        O.transform.position = transform.position;
        Object.Destroy(this.gameObject);
    }

}
