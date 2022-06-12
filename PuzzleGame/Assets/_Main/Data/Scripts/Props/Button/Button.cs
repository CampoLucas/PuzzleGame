using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    private Animator _anim;


    [SerializeField] private Collider _button;
    
    public bool isPressed;
    public bool prevPressedState;
    
    public AudioSource pressedSound;
    public AudioSource releasedSound;
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _anim.SetBool("isPressed", isPressed);
        _button.enabled = !isPressed;

        if (isPressed && prevPressedState != isPressed)
            Pressed();
        if (!isPressed && prevPressedState != isPressed)
            Released();
    }

    private void Pressed()
    {
        prevPressedState = isPressed;
        pressedSound.pitch = 1;
        pressedSound.Play();
        onPressed.Invoke();
    }

    private void Released()
    {
        prevPressedState = isPressed;
        releasedSound.pitch = Random.Range(1.1f, 1.2f);
        releasedSound.Play();
        onReleased.Invoke();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        isPressed = true;
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        isPressed = true;
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }

    public void WritePressed() => Debug.Log("Pressed");
    public void WriteReleased() => Debug.Log("Released");
}
