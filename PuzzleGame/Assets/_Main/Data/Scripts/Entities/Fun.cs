using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private bool _isOn = false;
    public bool prevState;

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
            Debug.Log("b");
            other.GetComponent<Rigidbody>().AddForce(transform.up * _force * Time.deltaTime, ForceMode.Force);

            Player _player = other.GetComponent<Player>();
            if (_player != null)
                _player.DisableGravity(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player _player = other.GetComponent<Player>();
        if (_player != null)
            _player.DisableGravity(true);
    }
}
