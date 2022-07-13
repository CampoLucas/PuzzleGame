using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    private Animator _anim;
    
    public bool isPressed;
    public bool prevPressedState;
    
    public UnityEvent onPressed;
    protected virtual void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        _anim.SetBool("isPressed", isPressed);
        
        if (isPressed && prevPressedState != isPressed)
            Pressed();
        if (!isPressed && prevPressedState != isPressed)
            Released();
    }

    protected virtual void Pressed()
    {
        prevPressedState = isPressed;
        AudioManager.instance.Play("ButtonOn");
        onPressed.Invoke();
    }

    protected virtual void Released()
    {
        prevPressedState = isPressed;
        AudioManager.instance.Play("ButtonOff");
    }
    
    protected virtual void OnTriggerEnter(Collider other)
    {
    }
    protected virtual void OnTriggerStay(Collider other)
    {
    }

    protected virtual void OnTriggerExit(Collider other)
    {
    }
}
