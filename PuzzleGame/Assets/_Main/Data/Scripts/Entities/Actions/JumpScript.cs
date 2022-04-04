using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public bool isJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isJump)
        {
            Jump();
        }
    }

    private void LateUpdate()
    {
        isJump = false;
    }

    private void Jump()
    {
        Debug.Log("aaa");
        _rigidbody.AddForce(Vector3.up * 250000 * Time.deltaTime, ForceMode.Impulse);

    }
}
