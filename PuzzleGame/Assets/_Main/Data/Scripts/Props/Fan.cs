using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjType;
using Random = UnityEngine.Random;

public class Fan : Prop
{
    private Animator _anim;
    private ParticleSystem _windParticles;
    
    [SerializeField] private bool _state;
    private bool prevState;
    
    
    private float _currentForce;
    [SerializeField] private float _force = 200f;
    
    public AudioSource turnOnSound;
    public AudioSource turnOffSound;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _windParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        if (_windParticles)
        {
            if(_state)
                _windParticles.Play();
            else
                _windParticles.Stop();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("IsOn", _state);

        if (_state && prevState != _state)
            TurnOn();
        if (!_state && prevState != _state)
            TurnOff();


    }

    private void TurnOn()
    {
        prevState = _state;

        if (turnOnSound)
        {
            turnOnSound.pitch = 1;
            turnOnSound.Play();
        }
        
        if(_windParticles)
            _windParticles.Play();
    }

    private void TurnOff()
    {
        prevState = _state;
        if (turnOffSound)
        {
            turnOffSound.pitch = Random.Range(1.1f, 1.2f);
            turnOffSound.Play();
        }
        
        if(_windParticles)
            _windParticles.Stop();
    }

    public void SetState(bool isOn) => _state = isOn;
    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (_state)
        {
            Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
            if (obj)
            {
                if (obj.Data.Type == ObjType.light)
                    _currentForce = _force * 2.5f;
                else if (obj.Data.Type == ObjType.heavy)
                    _currentForce = 0;
                else
                    _currentForce = _force;
                
                other.GetComponent<Collider>().GetComponentInParent<Rigidbody>().AddForce(transform.up * _currentForce * Time.deltaTime, ForceMode.Force);
            }

            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();
                if (player)
                    player.SetIsInteracting(true);
            }
                

        }
    }
    
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (_state)
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();
                if (player)
                    player.SetIsInteracting(true);
            }
        }
    }
    
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();
            if (player)
                player.SetIsInteracting(false);
        }
    }
}
