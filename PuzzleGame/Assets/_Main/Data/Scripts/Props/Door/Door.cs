using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private bool _isOpened;
    public bool prevState;

    [SerializeField] private string _nextLevel;

    [SerializeField] private bool _mute;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("isOpened", _isOpened);

        if (_isOpened && prevState != _isOpened)
            OpenDoor();
        if (!_isOpened && prevState != _isOpened)
            CloseDoor();

    }

    private void OpenDoor()
    {
        prevState = _isOpened;
        if(!_mute)
            AudioManager.instance.Play("DoorOn");
    }

    private void CloseDoor()
    {
        prevState = _isOpened;
        //FindObjectOfType<AudioManager>().Play("DoorOff");
        if(!_mute)
            AudioManager.instance.Play("DoorOff");
    }

    public void SetDoor(bool isOpen) => _isOpened = isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpened)
        {
            if (_nextLevel == "")
                GameManager.instance.LoadLevel();
            else
                GameManager.instance.LoadLevel(_nextLevel);
        }
    }

}
