using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : SphereRange
{
    public void ActivateButton()
    {
        foreach (var other in _hitColliders)
        {
            PedestalButton button = other.GetComponent<Collider>().GetComponentInParent<PedestalButton>();

            if (button)
                button.isPressed = true;
        }
    
    }
}
