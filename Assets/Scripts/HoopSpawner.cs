using UnityEngine;

public class HoopSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _rightHoop = default;
    [SerializeField] private Vector3 _leftHoop = default;

    private static bool _isRigth = false;

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
            hoop.SetActive(true);
        }
        else
        {
            UpdateLeftHoopPos();
            var hoop = PoolManager.Instance.GetPooledObject(new Vector3(_rightHoop.x, ballPos.y + Random.Range(1.5f, 3f), ballPos.z), Quaternion.identity);
            _isRigth = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            var ballPos = transform.position;
            Spawner(ballPos);
        }
        gameObject.SetActive(false);
    }
}
