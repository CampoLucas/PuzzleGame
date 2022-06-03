using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swap2 : MonoBehaviour
{
    public StatsSO form;

    public StatsSO[] formSlots = new StatsSO[1];

    public int currentFormIndex = 0;

    public List<StatsSO> formList;

    public UnityEvent onChangeForm = new UnityEvent();

    private void Awake()
    {
        
    }

    private void Start()
    {
        form = formSlots[0];
    }

    public void ChangeRight()
    {
        currentFormIndex = currentFormIndex + 1;
        
        if (currentFormIndex > formSlots.Length - 1)
            currentFormIndex = 0;

        SlotOrder();
        
        onChangeForm?.Invoke();
        
    }
    
    public void ChangeLeft()
    {
        currentFormIndex = currentFormIndex - 1;
        
        if (currentFormIndex < 0)
            currentFormIndex = formSlots.Length - 1;

        SlotOrder();
        
        onChangeForm?.Invoke();
        
    }

    private void SlotOrder()
    {
        for (int i = 0; i < formSlots.Length; i++)
        {
            if (formSlots[i] != null)
                form = formSlots[currentFormIndex];
            else
                currentFormIndex = currentFormIndex + 1;
        }
    }

    public void ChangeFormRight()
    {
        // currentFormIndex = currentFormIndex + 1;
        //
        // if (currentFormIndex > formSlots.Length - 1)
        //     currentFormIndex = -1;
        //
        // if (currentFormIndex == 0 && formSlots[0] != null)
        //     form = formSlots[currentFormIndex];
        // else if (currentFormIndex == 0 && formSlots[0] == null)
        //     currentFormIndex = currentFormIndex + 1;
        // else if (currentFormIndex == 1 && formSlots[1] != null)
        //     form = formSlots[currentFormIndex];
        // else if (currentFormIndex == 1 && formSlots[1] == null)
        //     currentFormIndex = currentFormIndex + 1;
        
        currentFormIndex = currentFormIndex + 1;
        
        // if (currentFormIndex > formSlots.Length - 1)
        //     currentFormIndex = 0;
        //
        // switch (currentFormIndex)
        // {
        //     case 0:
        //         if (formSlots[0] != null)
        //             form = formSlots[currentFormIndex];
        //         else
        //             currentFormIndex = currentFormIndex + 1;
        //         return;
        //     case 1:
        //         if (formSlots[1] != null)
        //             form = formSlots[currentFormIndex];
        //         else
        //             currentFormIndex = currentFormIndex + 1;
        //         return;
        //     case 2:
        //         if (formSlots[2] != null)
        //             form = formSlots[currentFormIndex];
        //         else
        //             currentFormIndex = currentFormIndex + 1;
        //         return;
        // }
        
        if (currentFormIndex > formSlots.Length - 1)
            currentFormIndex = 0;

        for (int i = 0; i < formSlots.Length; i++)
        {
            if (formSlots[i] != null)
                form = formSlots[currentFormIndex];
            else
                currentFormIndex = currentFormIndex + 1;
        }
        
        onChangeForm?.Invoke();
    }
}
