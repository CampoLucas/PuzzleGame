using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private bool _isOn = false;
    public bool prevState;

    private float _currentForce;
    [SerializeField] private float _force = 200f;

    public AudioSource turnOnSound;
    public AudioSource turnOffSound;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("IsOn", _isOn);

        if (_isOn && prevState != _isOn)
            TurnOn();
        if (!_isOn && prevState != _isOn)
            TurnOff();


    }

    private void TurnOn()
    {
        prevState = _isOn;
        turnOnSound.pitch = 1;
        turnOnSound?.Play();
    }

    private void TurnOff()
    {
        prevState = _isOn;
        turnOffSound.pitch = Random.Range(1.1f, 1.2f);
        turnOffSound?.Play();
    }

    public void SetState(bool isOn) => _isOn = isOn;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("a");
        if (_isOn)
        {
            Player _player = other.GetComponent<Player>();
            if (_player != null)
            {
                _player.DisableGravity(false);
                if (_player.Data.ID == "PPM")
                    _currentForce = _force * 2.5f;
                else if (_player.Data.ID == "PSR")
                    _currentForce = _force;
                else
                    _currentForce = 0f;
                _player.GetComponent<Rigidbody>().AddForce(transform.up * _currentForce * Time.deltaTime, ForceMode.Force);
            }
            else
            {
                _currentForce = _force;
                other.GetComponent<Rigidbody>().AddForce(transform.up * _currentForce * Time.deltaTime, ForceMode.Force);
            }
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player _player = other.GetComponent<Player>();
        if (_player != null)
            _player.DisableGravity(true);
    }
}
