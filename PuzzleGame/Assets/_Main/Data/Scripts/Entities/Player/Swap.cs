using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swap : MonoBehaviour
{
    // public StatsSO CurrentForm => _currentForm;
    // [SerializeField] private StatsSO _currentForm;
    
    public StatsSO GetCurrentStats => _formSlots[_currentFormIndex];
    
    [Header("Forms Slots")]
    [SerializeField] private StatsSO[] _formSlots = new StatsSO[1];
    [SerializeField] private int _currentFormIndex = 0;

    //public List<StatsSO> formList;
    
    [Header("Everything else")]
    [SerializeField] private GameObject[] _formGameObjects;
    private Rigidbody _rigidbody;


    [Header("Events")] 
    public UnityEvent OnBeforeChangeForm = new UnityEvent();
    public UnityEvent OnAfterChangeForm = new UnityEvent();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetValues();
    }

    public void ChangeForm(bool right)
    {
        OnBeforeChangeForm?.Invoke();
        _currentFormIndex = right ? _currentFormIndex + 1 : _currentFormIndex - 1;
        
        if (right && _currentFormIndex > _formSlots.Length - 1)
            _currentFormIndex = 0;

        if (!right && _currentFormIndex < 0)
            _currentFormIndex = _formSlots.Length - 1;

        SetValues();

        OnAfterChangeForm?.Invoke();
    }

    public void SetValues()
    {
        SlotOrder();
        DisableModels();
        ChangeValues();
    }

    public void SlotOrder()
    {
        for (int i = 0; i < _formSlots.Length; i++)
        {
            if (!_formSlots[i])
                _currentFormIndex = _currentFormIndex + 1;
        }
    }

    public void DisableModels()
    {
        for (int i = 0; i < _formGameObjects.Length; i++)
        {
            
            if (_formGameObjects[i] != _formGameObjects[_currentFormIndex])
                _formGameObjects[i].SetActive(false);
            else
                _formGameObjects[i].SetActive(true);
        }
        
    }

    public void ChangeValues()
    {
        // _hand.position = _currentForm.HandPosition;
        // _rayPos.position = _currentForm.RayPosition + transform.position;

        _rigidbody.mass = _formSlots[_currentFormIndex].Mass;
        _rigidbody.drag = _formSlots[_currentFormIndex].Drag;
    }

}
