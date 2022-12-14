using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static event Action<Vector3> SpawnedHoop = delegate { };
    public static event Action BallFlew = delegate { };
    public static event Action BallFlewOut = delegate { };
    public static event Action GameOver = delegate { };

    private Rigidbody2D rb = null;

    public Vector3 Pos { get { return transform.position; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Net"))
        {
            SpawnedHoop(transform.position);
        }

        if (collision.gameObject.CompareTag("Hoop"))
        {
            BallFlew();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hoop"))
        {
            BallFlewOut();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CameraFollow>())
        {
            gameObject.SetActive(false);
            GameOver();
        }
    }
}
