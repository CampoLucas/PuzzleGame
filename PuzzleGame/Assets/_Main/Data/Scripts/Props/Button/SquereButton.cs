using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquereButton : Button
{
    
    protected override void OnTriggerEnter(Collider other)
    {
        Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
        if(obj.Data.ID == "Player_Cube")
            isPressed = true;
        else
            isPressed = false;
    }
    protected override void OnTriggerStay(Collider other)
    {
        Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
        if(obj.Data.ID == "Player_Cube")
            isPressed = true;
        else
            isPressed = false;
    }

    protected override void OnTriggerExit(Collider other)
    {
        Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
        if(obj.Data.ID == "Player_Cube")
            isPressed = true;
    }
}
