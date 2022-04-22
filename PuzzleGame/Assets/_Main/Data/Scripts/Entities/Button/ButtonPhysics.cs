using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPhysics : MonoBehaviour
{
    public Transform buttonTop;                     //Saves the top of the button, the thing that moves within the base.
    public Transform buttonLowerLimit;              //Lower and upper limit are transforms to track the upper and lowwer limit we want the top of the button to be contained.
    public Transform buttonUpperLimit;
    public float threshHold;                        //The treshHold is a value between 0 and 1, that we use to calculate whether or not the button should be trigger.
    public float force = 10;                        //It will be used to provide a string force to return to the top position.
    private float upperLowerDiff;                   //Upper and lower difference is a variable that we use, with the threshHold variable, to calculate whether or not the isPressed bool should be on or off.
    public bool isPressed;
    public bool prevPressedState;                  //Is use so the unity events are only triggered once
    public AudioSource pressedSound;
    public AudioSource releasedSound;
    public UnityEvent onPressed;
    public UnityEvent onReleased;
    private void Start()
    {


        Physics.IgnoreCollision(GetComponent<Collider>(), buttonTop.GetComponent<Collider>());
        if (transform.eulerAngles != Vector3.zero)
        {
            Vector3 saveAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = saveAngle;
        }
        else
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    private void Update()
    {
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else
            buttonTop.GetComponent<Rigidbody>().AddForce(buttonTop.transform.up * force * Time.fixedDeltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);

        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
            isPressed = true;
        else
            isPressed = false;

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
        //prevPressedState = false;
        onReleased.Invoke();
    }

    public void WritePressed() => Debug.Log("Pressed");
    public void WriteReleased() => Debug.Log("Released");
}
