using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private bool isOpened = false;
    public bool prevState;

    [SerializeField] private string nextLevel;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("isOpened", isOpened);

        if (isOpened && prevState != isOpened)
            OpenDoor();
        if (!isOpened && prevState != isOpened)
            CloseDoor();

    }

    private void OpenDoor()
    {
        prevState = isOpened;
        AudioManager.instance.Play("DoorOn");
    }

    private void CloseDoor()
    {
        prevState = isOpened;
        //FindObjectOfType<AudioManager>().Play("DoorOff");
        AudioManager.instance.Play("DoorOff");
    }

    public void SetDoor(bool isOpen) => isOpened = isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpened)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
