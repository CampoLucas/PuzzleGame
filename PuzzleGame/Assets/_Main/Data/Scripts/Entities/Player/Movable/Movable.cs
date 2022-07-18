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

    public Vector3 m_DetectorSize = Vector3.zero;
    public float m_DetectorOffsetZ =0.5f;
    public float m_DetectorOffsetY = 0.5f;



    public LayerMask m_LayerMask;

    private float stairing = 0f;


    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 25f;
    [Range(0, 1)] [SerializeField] float stepFront = 0.1f;


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
        //RaycastHit hitLower;
        //if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        //{
        //    RaycastHit hitUpper;
        //    if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
        //    {
        //        _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
        //        debug = "climb";
        //    }
        //}

        //RaycastHit hitLower45;
        //if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.1f))
        //{

        //    RaycastHit hitUpper45;
        //    if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 0.2f))
        //    {
        //        _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
        //        debug = "climb";
        //    }
        //}

        //RaycastHit hitLowerMinus45;
        //if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.1f))
        //{

        //    RaycastHit hitUpperMinus45;
        //    if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 0.2f))
        //    {
        //        _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
        //        debug = "climb";
        //    }
        //}

        //RaycastHit hitLower22;
        //if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(0.75f, 0, 1), out hitLower22, 0.1f))
        //{

        //    RaycastHit hitUpper22;
        //    if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(0.75f, 0, 1), out hitUpper22, 0.2f))
        //    {
        //        _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
        //        debug = "climb";
        //    }
        //}

        //RaycastHit hitLowerMinus22;
        //if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-0.75f, 0, 1), out hitLowerMinus22, 0.1f))
        //{

        //    RaycastHit hitUpperMinus22;
        //    if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-0.75f, 0, 1), out hitUpperMinus22, 0.2f))
        //    {
        //        _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
        //        debug = "climb";
        //    }
        //}

        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.

        Vector3 pos = Vector3.zero;
        pos.z = m_DetectorOffsetZ;
        pos.y = m_DetectorOffsetY;

        //Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position + pos, transform.localScale / 2, Quaternion.identity, m_LayerMask);

        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position + pos, m_DetectorSize * 2.0f, Quaternion.identity, m_LayerMask);


        int i = 0;
        //Check when there is a new collider coming into contact with the box
        if (hitColliders.Length > 0)
        {
            //Output all of the collider names
            //Debug.Log("Hit : " + hitColliders[i].name + i);
            Debug.Log("Climb");

            if (_player.IsGrounded && stairing >= 0.1f )
            {
                _rigidbody.position -= new Vector3(stepFront, -stepSmooth * Time.deltaTime, 0f);
                stairing = 0f;
            }
            //Increase the number of Colliders in the array

            stairing += Time.deltaTime;
            i++;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(stepRayLower.transform.position, 0.1f);
        Gizmos.DrawWireSphere(stepRayUpper.transform.position, 0.1f);

        //Gizmos.color = Color.green;
        ////Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //    //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        //    Gizmos.DrawWireCube(transform.position, transform.localScale);

        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Vector3 pos = Vector3.zero;
        pos.z = m_DetectorOffsetZ;
        pos.y = m_DetectorOffsetY;
        Gizmos.DrawWireCube(pos, m_DetectorSize * 2.0f);

    }
}
