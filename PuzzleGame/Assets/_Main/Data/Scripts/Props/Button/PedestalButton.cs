using UnityEngine;

public class PedestalButton : Button
{
    protected override void Pressed()
    {
        base.Pressed();
        isPressed = false;
    }
    // protected override void OnTriggerStay(Collider other)
    // {
    //     Player player = other.GetComponent<Collider>().GetComponentInParent<Player>();
    //     
    //     if (player && player.IsPressingButton)
    //     {
    //         isPressed = true;
    //     }
    //
    // }
}
