using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _offsetY;
    
    public void Action()
    {
        Collider[] hitColliders =
            Physics.OverlapSphere(
                new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z), _radius);

        foreach (var other in hitColliders)
        {
            Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
            if (obj && obj.Data.Type == ObjType.wood)
            {
                // if(obj.Data.ID == "Wood_Box")
                //     obj.Respawn();
                // else
                other.gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.91f, 0.56f, 0.12f);
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z), _radius);
    }
}
