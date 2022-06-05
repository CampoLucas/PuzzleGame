using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swap : MonoBehaviour
{
    public StatsSO CurrentForm => _currentForm;
    [SerializeField] private StatsSO _currentForm;
    
    [Header("Forms Slots")]
    [SerializeField] private StatsSO[] _formSlots = new StatsSO[1];
    [SerializeField] private int _currentFormIndex = 0;

    //public List<StatsSO> formList;
    
    [Header("Everything else")]
    [SerializeField] private GameObject _currentGameObject;
    [SerializeField] private GameObject[] _formGameObjects;
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _rayPos;
    private Rigidbody _rigidbody;

    
    [Header("Events")]
    public UnityEvent onChangeForm = new UnityEvent();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentForm = _formSlots[0];
        _currentGameObject = _formGameObjects[0];
    }

    public void ChangeRight()
    {
        _currentFormIndex = _currentFormIndex + 1;
        
        if (_currentFormIndex > _formSlots.Length - 1)
            _currentFormIndex = 0;

        SlotOrder();
        DisableModels();
        ChangeValues();
        
        onChangeForm?.Invoke();
        
    }
    
    public void ChangeLeft()
    {
        _currentFormIndex = _currentFormIndex - 1;
        
        if (_currentFormIndex < 0)
            _currentFormIndex = _formSlots.Length - 1;

        SlotOrder();
        DisableModels();
        ChangeValues();
        
        onChangeForm?.Invoke();
        
    }

    private void SlotOrder()
    {
        for (int i = 0; i < _formSlots.Length; i++)
        {
            if (_formSlots[i])
                _currentForm = _formSlots[_currentFormIndex];
            else
                _currentFormIndex = _currentFormIndex + 1;
        }
    }

    private void DisableModels()
    {
        for (int i = 0; i < _formGameObjects.Length; i++)
        {
            
            if (_formGameObjects[i] != _formGameObjects[_currentFormIndex])
                _formGameObjects[i].SetActive(false);
            else
                _formGameObjects[i].SetActive(true);
        }
        
    }

    private void ChangeValues()
    {
        //_hand.position = _currentForm.HandPosition;
        //_rayPos.position = _currentForm.RayPosition;
        
        _hand.position = _currentForm.HandPosition + transform.position;
        _rayPos.position = _currentForm.RayPosition + transform.position;

        _rigidbody.mass = _currentForm.Mass;
        _rigidbody.drag = _currentForm.Drag;
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
        
        _currentFormIndex = _currentFormIndex + 1;
        
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
        
        if (_currentFormIndex > _formSlots.Length - 1)
            _currentFormIndex = 0;

        for (int i = 0; i < _formSlots.Length; i++)
        {
            if (_formSlots[i] != null)
                _currentForm = _formSlots[_currentFormIndex];
            else
                _currentFormIndex = _currentFormIndex + 1;
        }
        
        onChangeForm?.Invoke();
    }
}
