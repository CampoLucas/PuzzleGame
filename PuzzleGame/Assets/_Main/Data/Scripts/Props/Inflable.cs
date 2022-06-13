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
            if (player.Data.ID == "Player_Sphere")
            {
                _anim.SetTrigger("Player_Sphere");
                _anim.SetBool("On", true);
            }
            else
            {
                _anim.ResetTrigger("Player_Sphere");
                _anim.SetBool("On", false);
            }

            if (player.Data.ID == "Player_Cube")
            {
                _anim.SetTrigger("Player_Cube");
                _anim.SetBool("On", true);
            }
            else
            {
                _anim.ResetTrigger("Player_Cube");
                _anim.SetBool("On", false);
            }
            
        }
    }
        
}
