using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public int Life => _life;
    [SerializeField] private int _life = 100;
    public int Damage => _damage;
    [SerializeField] private int _damage = 10;
    public float Speed => _speed;
    [SerializeField] private float _speed = 7;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField] private float _rotationSpeed = 10;
    public float JumpSpeed => _jumpSpeed;
    [SerializeField] private float _jumpSpeed = 30;

}
