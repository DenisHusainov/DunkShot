using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private const int _amountToPool = 5;

    [SerializeField] private GameObject _hoopToPool = null;
    [SerializeField] private GameObject _ObjectContainer = null;

    private List<GameObject> _poolObjects = new List<GameObject>();

    private void Start()
    {
        GameObject tmp;

        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_hoopToPool, Vector3.zero, Quaternion.identity, _ObjectContainer.transform);
            tmp.SetActive(false);
            _poolObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!_poolObjects[i].activeInHierarchy)
            {
                _poolObjects[i].transform.SetPositionAndRotation(position, rotation);

                return _poolObjects[i];
            }
        }
        return null;
    }

}