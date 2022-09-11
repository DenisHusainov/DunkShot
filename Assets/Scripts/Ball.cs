using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D col;

    public Vector3 Pos { get { return transform.position; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        InputManager.AtivatedRb += InputManager_AtivatedRb;
        InputManager.DesativatedRb += InputManager_DesativatedRb;
    }

    private void OnDisable()
    {
        InputManager.AtivatedRb -= InputManager_AtivatedRb;
        InputManager.DesativatedRb -= InputManager_DesativatedRb;
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void ActivareRb()
    {
        rb.isKinematic = false;
    }

    private void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    private void InputManager_AtivatedRb()
    {
        ActivareRb();
    }

    private void InputManager_DesativatedRb()
    {
        DesactivateRb();
    }
}
