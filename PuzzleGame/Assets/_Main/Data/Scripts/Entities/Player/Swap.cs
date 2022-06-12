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

    public void SlotOrder()
    {
        for (int i = 0; i < _formSlots.Length; i++)
        {
            if (_formSlots[i])
                _currentForm = _formSlots[_currentFormIndex];
            else
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

        _rigidbody.mass = _currentForm.Mass;
        _rigidbody.drag = _currentForm.Drag;
    }
}
