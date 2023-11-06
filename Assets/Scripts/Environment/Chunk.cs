using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    public Road Road;

    [SerializeField]
    public Street Street;

    [SerializeField]
    public StreetLightsChain StreetLamp;

    public void Init()
    {
        Road.Init();
        Street.Init(Road);
        StreetLamp.Init(Road);

        Road.gameObject.SetActive(true);
        Street.gameObject.SetActive(true);
        StreetLamp.gameObject.SetActive(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
