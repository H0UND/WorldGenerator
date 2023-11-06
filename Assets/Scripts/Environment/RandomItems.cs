using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItems : MonoBehaviour
{
    [SerializeField]
    private Transform[] _items;

    void Start()
    {
        if (_items == null)
        {
            return;
        }

        if (_items.Length == 0f)
        {
            return;
        }

        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].gameObject.SetActive(Random.Range(0,2) == 0f);
        }
    }
}
