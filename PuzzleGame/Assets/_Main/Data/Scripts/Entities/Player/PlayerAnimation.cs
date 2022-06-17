using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private int _horizontal;
    private int _vertical;
    private int _jump;

    public void Awake()
    {
        _anim = GetComponent<Animator>();
        _horizontal = Animator.StringToHash("Horizontal");
        _vertical = Animator.StringToHash("Vertical");
        
        _jump = Animator.StringToHash("Jump");
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
        
        _anim.SetFloat(_horizontal, h, 0.1f, Time.deltaTime);
        _anim.SetFloat(_vertical, v, 0.1f, Time.deltaTime);
    }

    public void ToggleJump()
    {
        _anim.SetTrigger(_jump);
    }
}
