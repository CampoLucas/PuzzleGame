using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerForm", menuName = "Entities/PlayerForm", order = 1)]
public class PlayerForm : ScriptableObject
{
    public GameObject modelPrefab;
    
    [Header("Hand components")]
    public Vector3 handPosition;
    
    [Header("Head collider")]
    public Vector3 headCenter;
    public float headRadius;
    public float headHeight;
    
    [Header("Body Collider")]
    public Vector3 bodyCenter;
    public float bodyRadius;
    public float bodyHeight;
    
}
