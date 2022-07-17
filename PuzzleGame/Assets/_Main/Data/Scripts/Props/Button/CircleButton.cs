using UnityEngine;
using UnityEngine.Events;

public class CircleButton : Button
{
    public UnityEvent onReleased;
    
    [SerializeField] private Collider _button;
    

    protected override void Update()
    {
        _button.enabled = !isPressed;
        base.Update();
    }

    protected override void Released()
    {
        base.Released();
        onReleased.Invoke();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        isPressed = true;
    }
    protected override void OnTriggerStay(Collider other)
    {
        isPressed = true;
    }

    protected override void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }
    //
    // public void WritePressed() => Debug.Log("Pressed");
    // public void WriteReleased() => Debug.Log("Released");
}
