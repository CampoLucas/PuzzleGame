using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.GetComponent<Collider>().GetComponentInParent<Entity>();
        
        if(entity)
            entity.Respawn();
    }
}
