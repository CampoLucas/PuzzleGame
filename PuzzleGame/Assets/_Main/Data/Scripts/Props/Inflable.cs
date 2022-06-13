using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflable : Prop
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
        _anim.SetTrigger("Inflate");
        _anim.ResetTrigger("Sphere");
    }

    private void Deflate()
    {
        prevState = IsPressed;
        _anim.ResetTrigger("Inflate");
        _anim.ResetTrigger("Sphere");
    }

    public void Setinflate(bool isOpen) => IsPressed = isOpen;

    protected override void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();

        if (player)
        {
            if (player.Data.ID == "PSR")
            {
                _anim.SetTrigger("Sphere");
                _anim.SetBool("On", true);
            }
            else
            {
                _anim.ResetTrigger("Sphere");
            }

            if (player.Data.ID == "PCB")
            {
                _anim.SetTrigger("Pressed");
            }
            else
            {
                _anim.ResetTrigger("Pressed");
                _anim.SetBool("On", true);
            }

                       

        }


    }
      
}
