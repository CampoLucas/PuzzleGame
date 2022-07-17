using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movable : MonoBehaviour, IMovable
{
    private Rigidbody _rigidbody;

    private Player _player;

    private Vector3 _forceDirection = Vector3.zero;

    [SerializeField] private Transform _camera;

    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 10f;
    [Range(0, 1)] [SerializeField] float stepFront = 0f;


    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        if (Camera.main != null) _camera = Camera.main.transform;

        stepRayUpper.transform.position = new Vector3(stepRayLower.transform.position.x, stepHeight, stepRayLower.transform.position.z);
    }

    public void Move(Vector3 direction)
    {

        if (_player.IsGrounded)
             stepClimb();
        float currentForce;
        if (!_player.IsGrounded)
            currentForce = _player.GetStats.MovementForce / 3;
        else
            currentForce = _player.GetStats.MovementForce;
        
        
        _forceDirection = _camera.forward * direction.y;
        _forceDirection += _camera.right * direction.x;
        _forceDirection.Normalize();
        _forceDirection.y = 0;
        _forceDirection *= currentForce;

        //Por que?
        //forceDirection.y += -10;
        _rigidbody.AddForce(_forceDirection);

        _forceDirection = Vector3.zero;
        //Creo que esto deveria ir en otro script
        if (_rigidbody.velocity.y < 0f && !_player.IsInteracting)
            _rigidbody.velocity -= Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime);

        //Encontre el problema de planear... era que estaba siendo multiplicado por Time.deltatime, igual la comento porque en jumpable hace lo mismo
        // Vector3 horizontalVelocity = _rigidbody.velocity;
        // horizontalVelocity.y = 0;
        // if (horizontalVelocity.sqrMagnitude > _player.GetStats.MaxSpeed * _player.GetStats.MaxSpeed)
        //     _rigidbody.velocity = horizontalVelocity.normalized * _player.GetStats.MaxSpeed + Vector3.up * _rigidbody.velocity.y;

        HandleRotation(direction);
    }

    private void HandleRotation (Vector3 direction)
    {
        Vector3 targetDirection;

        targetDirection = _camera.forward * direction.y;
        targetDirection += _camera.right * direction.x;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _player.GetStats.RotationSpeed);

        transform.rotation = playerRotation;

        stepRayLower.transform.rotation = transform.rotation;
        stepRayUpper.transform.rotation = transform.rotation;

    }

    void stepClimb()
    {
        var debug = "Don't climb";
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
            {
                _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
                debug = "climb";
            }
        }

        RaycastHit hitLower45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.1f))
        {

            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 0.2f))
            {
                _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
                debug = "climb";
            }
        }

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f))
        {

            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f))
            {
                _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
                debug = "climb";
            }
        }

        RaycastHit hitLower22;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(0.75f, 0, 1), out hitLower22, 0.1f))
        {

            RaycastHit hitUpper22;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(0.75f, 0, 1), out hitUpper22, 0.2f))
            {
                _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
                debug = "climb";
            }
        }

        RaycastHit hitLowerMinus22;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-0.75f, 0, 1), out hitLowerMinus22, 0.1f))
        {

            RaycastHit hitUpperMinus22;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-0.75f, 0, 1), out hitUpperMinus22, 0.2f))
            {
                _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
                debug = "climb";
            }
        }
        Debug.Log(debug);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(stepRayLower.transform.position, 0.1f);
        Gizmos.DrawWireSphere(stepRayUpper.transform.position, 0.1f);

    }
}
