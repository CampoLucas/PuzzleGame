using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    public void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void UpdateAnimatorValues(float horizontal, float vertical)
    {
        float h = Mathf.Abs(horizontal);
        float v = Mathf.Abs(vertical);

        // if (horizontal < .55f || horizontal > -.55f)
        //     h = 0;
        //
        // if (vertical < .55f || vertical > -.55f)
        //     v = 0;
        
        _anim.SetFloat("Horizontal", h, 0.1f, Time.deltaTime);
        _anim.SetFloat("Vertical", v, 0.1f, Time.deltaTime);
    }
}
