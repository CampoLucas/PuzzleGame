using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflable : MonoBehaviour
{
    [SerializeField] private bool IsPressed = false;
    public bool prevState;

    private Animator _anim;
       
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    } 
    
    void Update()
    {
        _anim.SetBool("IsPressed", IsPressed);

        if (IsPressed && prevState != IsPressed)
            Inflate();
        if (!IsPressed && prevState != IsPressed)
            Deflate();
    }

    private void Inflate()
    {
        prevState = IsPressed;
    }

    private void Deflate()
    {
        prevState = IsPressed;
    }

    public void Setinflate(bool isOpen) => IsPressed = isOpen;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();

        if (player)
        {
            if (player.Data.ID == "PSR" && IsPressed)
            {
                _anim.SetBool("IsSphereOn", true);
            }
            else
            {
                _anim.SetBool("IsSphereOn", false);
            }

            if (player.Data.ID == "PCB" && other.gameObject.CompareTag("Player"))
            {
                _anim.SetBool("IsCubeOn", true);
            }
            else
            {
                _anim.SetBool("IsCubeOn", false);
            }

                       

        }


    }
      
}
