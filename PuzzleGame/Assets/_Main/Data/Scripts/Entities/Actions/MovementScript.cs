using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsScript))]
public class MovementScript : MonoBehaviour
{
    [Header("Components")]
    private StatsScript _stats;
    private Rigidbody _rigidbody;

    [Header("Stats")]
    private float _speed;
    private float _rotationSpeed;

    [Header("Movement Components")]
    public float horizontal;
    public float vertical;
    private float moveAmount;
    public Vector3 moveDirection;
    [HideInInspector] public Transform myTransform;


    private void Awake()
    {
        _stats = GetComponent<StatsScript>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        myTransform = transform;
        _speed = _stats.Stats.Speed;
        _rotationSpeed = _stats.Stats.RotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        
        HandleMovement(delta);
    }

    #region Movement
    Vector3 normalVector;

    private void HandleMovement(float delta)
    {
        MoveAmount();
        Movement(delta);
    }

    private void MoveAmount() => moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

    private void Rotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;
        float moveOverride = moveAmount;

        targetDir = new Vector3(horizontal, 0f, vertical);

        targetDir.Normalize();
        //targetDir.y = 0;

        if (targetDir == Vector3.zero)
            targetDir = myTransform.forward;

        float rs = _rotationSpeed; // rs == rotation speed

        Quaternion tr = Quaternion.LookRotation(targetDir); // tr == target rotation
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;
    }

    private void Movement(float delta)
    {
        moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection.Normalize();

        float speed = _speed;

        //Codigo si queremos hacer que pueda correr


        moveDirection *= speed;


        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        _rigidbody.velocity = projectedVelocity;

        Rotation(delta);
    }

    #endregion
}
