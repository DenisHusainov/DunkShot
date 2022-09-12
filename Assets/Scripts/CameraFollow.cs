using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _ball = null;

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x,
            Mathf.Lerp(transform.position.y, _ball.position.y + 2f, 0.03f),
            transform.position.z);
    }
}
