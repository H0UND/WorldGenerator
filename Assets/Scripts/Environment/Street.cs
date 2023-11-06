using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField]
    private Building _leftBuild;

    [SerializeField]
    private Building _rightBuild;

    [SerializeField]
    private Building _forwardBuild;

    [SerializeField]
    private Building _backBuild;

    [SerializeField]
    private Building[] _builds;

    [SerializeField]
    private GameObject NorthTrashes;
    [SerializeField]
    private GameObject SouthTrashes;
    [SerializeField]
    private GameObject WestTrashes;
    [SerializeField]
    private GameObject EastTrashes;

    internal void Init(Road road)
    {
        _leftBuild.Init(!road.Left, Random.Range(5, 25));
        _rightBuild.Init(!road.Right, Random.Range(5, 25));
        _forwardBuild.Init(!road.Forward, Random.Range(5, 25));
        _backBuild.Init(!road.Back, Random.Range(5, 25));

        foreach (var build in _builds)
        {
            build.Init(true, Random.Range(4, 10));
        }

        NorthTrashes.SetActive(road.Forward);
        SouthTrashes.SetActive(road.Back);
        WestTrashes.SetActive(road.Left);
        EastTrashes.SetActive(road.Right);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
