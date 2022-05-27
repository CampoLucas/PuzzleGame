using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ITriggerable
{
    Collider[] HitColliders { get; }
    UnityEvent OnCollition { get; }
}
