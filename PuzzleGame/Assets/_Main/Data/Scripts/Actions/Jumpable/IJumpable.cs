using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    float JumpForce { get; }
    float MaxSpeed { get; }
    void Jump();
    void DisableGravity(bool isGravity);
}
