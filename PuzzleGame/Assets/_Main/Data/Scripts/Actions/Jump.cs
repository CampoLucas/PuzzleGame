using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Player _playerScript;

    [Header("Components")]
    private Rigidbody _rigidbody;
    private Vector3 forceDirection = Vector3.zero;

    [Header("Stats")]//Despues van a ir en su script de stats
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private float maxSpeed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerScript = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * _rigidbody.velocity.y;
    }

    public void Do()
    {
        Debug.Log("jump");

        //forceDirection = Vector3.zero;
        if (_playerScript.isGrounded())
        forceDirection += Vector3.up * jumpForce;
        //_rigidbody.AddForce(Vector3.up * jumpForce); 


    }

    //private bool IsGrounded()
    //{

    //    Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);

    //    Debug.Log(Vector3.down);
    //    if (Physics.Raycast(ray, out RaycastHit hit, 0.3f, 1 >> 6))
    //        return true;
    //    else
    //        Debug.Log("no toca");
    //    return false;

    //}
}
