using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float force = 200f;
    [SerializeField] private LayerMask layerMask;
    
    [Header("collitionPos1")]
    [Header("Collition 1")]
    [SerializeField] private Transform collition1;
    [SerializeField] private Color color = Color.blue;
    

    private void FixedUpdate()
    {
        MyCollisions();
    }

    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapBox(collition1.position, collition1.localScale/2,
            Quaternion.identity, layerMask);
        int i = 0;
        if (hitColliders != null && i < hitColliders.Length)
        {
            foreach (Collider collition in hitColliders)
            {
                collition.GetComponent<Rigidbody>().AddForce(transform.up * force * Time.deltaTime, ForceMode.Impulse);
            }
            i++;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube(collition1.position, collition1.localScale);
    }
}
