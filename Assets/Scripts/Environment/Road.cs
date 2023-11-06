using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]
    public bool Left;

    [SerializeField]
    public bool Right;

    [SerializeField]
    public bool Forward;

    [SerializeField]
    public bool Back;

    [SerializeField]
    private Transform _leftRoad;

    [SerializeField]
    private Transform _rightRoad;

    [SerializeField]
    private Transform _forwardRoad;

    [SerializeField]
    private Transform _backRoad;

    internal void Init()
    {
        _leftRoad.gameObject.SetActive(Left);
        _rightRoad.gameObject.SetActive(Right);
        _forwardRoad.gameObject.SetActive(Forward);
        _backRoad.gameObject.SetActive(Back);
    }

    public int GetRoadCount()
    {
        return 
            Convert.ToInt32(Left) + 
            Convert.ToInt32(Right) + 
            Convert.ToInt32(Forward) + 
            Convert.ToInt32(Back); 
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
