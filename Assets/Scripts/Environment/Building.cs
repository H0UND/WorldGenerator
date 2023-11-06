using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private Transform _floorPrefab;

    private int _floorCount;
    private bool _enabled;

    internal void Init(bool enabled, int floor)
    {
        _enabled = enabled;
        if (_enabled)
        {

            for (int i = 1; i < floor; i++)
            {
                var position = new Vector3(transform.position.x, transform.position.y + i * 6, transform.position.z);

                var fl = Instantiate(_floorPrefab, position, Quaternion.identity, transform);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {

    }
}