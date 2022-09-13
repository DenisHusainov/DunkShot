using System.Collections.Generic;
using UnityEngine;

public class HoopSpawner : MonoBehaviour
{
    // Random conlict between using System and using UnityEngine
    public static event System.Action BallFlew = delegate { };

    private static List<GameObject> SpawnedHoops = new List<GameObject>();
    private static bool _isRigth = false;

    [SerializeField] private GameObject _net = null;

    private Vector3 _rightHoop = default;
    private Vector3 _leftHoop = default;

    private void OnEnable()
    {
        _net.SetActive(true);
        Ball.SpawnedHoop += Ball_SpawnedHoop;
    }

    private void OnDisable()
    {
        Ball.SpawnedHoop -= Ball_SpawnedHoop;
    }

    private void Start()
    {
        UpdateRightHoopPos();
        UpdateLeftHoopPos();
    }

    private void Spawner(Vector3 ballPos)
    {
        if (!_isRigth)
        {
            UpdateRightHoopPos();
            var hoop = PoolManager.Instance.GetPooledObject(new Vector3(_leftHoop.x, ballPos.y + Random.Range(1.5f, 3f), ballPos.z), Quaternion.identity);
            _isRigth = true;
            SpawnedHoops.Add(hoop);
            hoop.SetActive(true);
        }
        else
        {
            UpdateLeftHoopPos();
            var hoop = PoolManager.Instance.GetPooledObject(new Vector3(_rightHoop.x, ballPos.y + Random.Range(1.5f, 3f), ballPos.z), Quaternion.identity);
            _isRigth = false;
            SpawnedHoops.Add(hoop);
            hoop.SetActive(true);
        }
    }

    private void UpdateRightHoopPos()
    {
        _rightHoop.x = Random.Range(1.2f, 1.66f);
    }

    private void UpdateLeftHoopPos()
    {
        _leftHoop.x = Random.Range(-1.4f, -0.4f);
    }

    private void Ball_SpawnedHoop(Vector3 ballPosition)
    {
        _net.SetActive(false);
        var ballPos = ballPosition;
        Spawner(ballPos);
        BallFlew();
        this.enabled = false;

        if (SpawnedHoops.Count > 2)
        {
            SpawnedHoops[0].gameObject.GetComponent<HoopSpawner>().enabled = true;
            SpawnedHoops[0].gameObject.SetActive(false);
            SpawnedHoops.RemoveAt(0);
        }
    }
}
