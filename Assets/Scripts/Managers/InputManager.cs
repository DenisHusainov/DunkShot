using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public static event Action DesativatedRb = delegate { };
    public static event Action AtivatedRb = delegate { };
    public static event Action ShowedTrajectory = delegate { };
    public static event Action HidedTrajectory = delegate { };
    public static event Action<Vector3, Vector2> UpdatedDots = delegate { };

    [SerializeField] private float _pushForce = 4f;
    [SerializeField] private Ball ball;

    private Camera _cam = null;

    private Vector2 _startPoint = default;
    private Vector2 _endPoint = default;
    private Vector2 _direction = default;
    private Vector2 _force = default;

    private float _distance = default;
    private bool _isDragging = false;

    private void Start()
    {
        _cam = Camera.main;
        DesativatedRb();
    }

    private void Update()
    {
        if (!CanMove())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.IsFly == false)
        {
            _isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp(0) && GameManager.Instance.IsFly == false)
        {
            _isDragging = false;
            OnDragEnd();
        }

        if (_isDragging)
        {
            OnDrag();
        }
    }

    private void OnDragStart()
    {
        DesativatedRb();
        _startPoint = _cam.ScreenToWorldPoint(Input.mousePosition);

        ShowedTrajectory();
    }

    private void OnDrag()
    {
        _endPoint = _cam.ScreenToWorldPoint(Input.mousePosition);
        _distance = Vector2.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        _force = _direction * _distance * _pushForce;

        UpdatedDots(ball.Pos, _force);
    }

    private void OnDragEnd()
    {
        AtivatedRb();

        ball.Push(_force);

        HidedTrajectory();
    }

    private bool CanMove()
    {
        return GameManager.Instance.IsStarted && !GameManager.Instance.IsFinished;
    }
}
