using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLightsChain : MonoBehaviour
{
    [SerializeField]
    private Transform _leftLight;

    [SerializeField]
    private Transform _rightLight;

    [SerializeField]
    private Transform _forwardLight;

    [SerializeField]
    private Transform _backLight;

    internal void Init(Road road)
    {
        _leftLight.gameObject.SetActive(!road.Left);
        _rightLight.gameObject.SetActive(!road.Right);
        _forwardLight.gameObject.SetActive(!road.Forward);
        _backLight.gameObject.SetActive(!road.Back);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
