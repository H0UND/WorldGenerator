using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Chunk _chunk;

    private Dictionary<Vector3, Chunk> _chunks;

    [SerializeField]
    private GameObject _tag;

    private int _radius = 200;

    private void Start()
    {
        _chunks = new Dictionary<Vector3, Chunk>();

        for (int i = -_radius; i < _radius; i += 50)
        {
            for (int j = -_radius; j < _radius; j += 50)
            {
                var position = new Vector3(i, 0, j);
                var chunk = Instantiate(_chunk, position, Quaternion.identity, transform);

                CheckLeft(i, j, chunk);
                CheckRight(i, j, chunk);
                CheckForward(i, j, chunk);
                CheckBack(i, j, chunk);

                chunk.gameObject.name = $"({i})x({j})";

                _chunks.Add(position, chunk);

                chunk.Init();
            }
        }
    }

    private int _currentX = 0;
    private int _currentZ = 0;
    private Vector2 _currentPosition;

    private void Update()
    {
        var x = _playerTransform.transform.position.x;
        var z = _playerTransform.transform.position.z;

            _tag.transform.position = new Vector3(
                _playerTransform.transform.position.x, 
                550f,
                _playerTransform.transform.position.z);

        _currentX = (int)x / 50;
        _currentZ = (int)z / 50;

        if (_currentPosition.x != _currentX * 50f || _currentPosition.y != _currentZ * 50f)
        {
            _currentPosition = new Vector3(_currentX * 50f, _currentZ * 50f);
            GenerateFromCurrentPoint();
        }
    }

    private void GenerateFromCurrentPoint()
    {
        for (int i = (int)_currentPosition.x - _radius; i < (int)_currentPosition.x + _radius; i += 50)
        {
            for (int j = (int)_currentPosition.y - _radius; j < (int)_currentPosition.y + _radius; j += 50)
            {
                var position = new Vector3(i, 0, j);

                if (_chunks.ContainsKey(position))
                {
                    continue;
                }

                var chunk = Instantiate(_chunk, position, Quaternion.identity, transform);

                CheckLeft(i, j, chunk);
                CheckRight(i, j, chunk);
                CheckForward(i, j, chunk);
                CheckBack(i, j, chunk);

                chunk.gameObject.name = $"({i})x({j})";

                _chunks.Add(position, chunk);

                chunk.Init();
            }
        }
    }



    #region

    private int _outs = 1;

    private void CheckLeft(int i, int j, Chunk chunk)
    {
        var neighbor = new Vector3(i - 50, 0, j);
        if (_chunks.ContainsKey(neighbor))
        {
            if (_chunks[neighbor].Road.Right)
            {
                chunk.Road.Left = true;
            }
            else
            {
                chunk.Road.Left = false;
            }
        }
        else
        {
            if (chunk.Road.GetRoadCount() >= _outs)
            {
                chunk.Road.Left = Random.Range(0, 2) == 1;
            }
            else
            {
                chunk.Road.Left = true;
            }
        }
    }

    private void CheckRight(int i, int j, Chunk chunk)
    {
        var neighbor = new Vector3(i + 50, 0, j);
        if (_chunks.ContainsKey(neighbor))
        {
            if (_chunks[neighbor].Road.Left)
            {
                chunk.Road.Right = true;
            }
            else
            {
                chunk.Road.Right = false;
            }
        }
        else
        {
            if (chunk.Road.GetRoadCount() >= _outs)
            {
                chunk.Road.Right = Random.Range(0, 2) == 1;
            }
            else
            {
                chunk.Road.Right = true;
            }
        }
    }

    private void CheckForward(int i, int j, Chunk chunk)
    {
        var neighbor = new Vector3(i, 0, j + 50);
        if (_chunks.ContainsKey(neighbor))
        {
            if (_chunks[neighbor].Road.Back)
            {
                chunk.Road.Forward = true;
            }
            else
            {
                chunk.Road.Forward = false;
            }
        }
        else
        {
            if (chunk.Road.GetRoadCount() >= _outs)
            {
                chunk.Road.Forward = Random.Range(0, 2) == 1;
            }
            else
            {
                chunk.Road.Forward = true;
            }
        }
    }

    private void CheckBack(int i, int j, Chunk chunk)
    {
        var neighbor = new Vector3(i, 0, j - 50);
        if (_chunks.ContainsKey(neighbor))
        {
            if (_chunks[neighbor].Road.Forward)
            {
                chunk.Road.Back = true;
            }
            else
            {
                chunk.Road.Back = false;
            }
        }
        else
        {
            if (chunk.Road.GetRoadCount() >= _outs)
            {
                chunk.Road.Back = Random.Range(0, 2) == 1;
            }
            else
            {
                chunk.Road.Back = true;
            }
        }
    }

    #endregion
}