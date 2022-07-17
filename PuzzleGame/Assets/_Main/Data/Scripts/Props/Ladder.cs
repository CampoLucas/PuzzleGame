using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Transform _pos;
    [SerializeField] private float _step = 1;
    [SerializeField] private float _rotationSpeed = 10;
    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();

        if (player)
        {
            if(GameManager.instance.IsGameOver)
                return;
            var o = player.gameObject.transform;
            o.position = Vector3.MoveTowards(o.position,
                _pos.position, _step * Time.deltaTime);
                
            o.rotation = Quaternion.RotateTowards(o.rotation,
                _pos.rotation, _rotationSpeed * Time.deltaTime);
            
            if(player.gameObject.transform.position == _pos.position && player.gameObject.transform.rotation == _pos.rotation)
                player.SetIsClimbing(true);
        }
    }
}
