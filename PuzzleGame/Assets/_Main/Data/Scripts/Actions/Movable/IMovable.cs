using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float MovementForce { get; }
    float MaxSpeed { get; }
    void Move(Vector3 direction);

    void DisableGravity(bool isGravity);
}
