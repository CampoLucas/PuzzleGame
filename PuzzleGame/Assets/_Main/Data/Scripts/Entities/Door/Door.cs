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

    public AudioSource openedSound;
    public AudioSource closedSound;
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
        openedSound.pitch = 1;
        openedSound?.Play();
    }

    private void CloseDoor()
    {
        prevState = isOpened;
        closedSound.pitch = Random.Range(1.1f, 1.2f);
        closedSound?.Play();
    }

    public void SetDoor(bool isOpen) => isOpened = isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpened)
            SceneManager.LoadScene(nextLevel);
    }

}
