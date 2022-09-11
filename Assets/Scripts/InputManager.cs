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

    private Camera _cam;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _direction;
    private Vector2 _force;

    private float _distance;
    private bool _isDragging = false;

    public Ball ball;

    private void Start()
    {
        _cam = Camera.main;
        //ball.DesactivateRb();
        DesativatedRb();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
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
        //ball.DesactivateRb();
        DesativatedRb();
        _startPoint = _cam.ScreenToWorldPoint(Input.mousePosition);

        //trajectory.Show();
        ShowedTrajectory();
    }

    private void OnDrag()
    {
        _endPoint = _cam.ScreenToWorldPoint(Input.mousePosition);
        _distance = Vector2.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        _force = _direction * _distance * _pushForce;

        //trajectory.UpdateDots(ball.Pos, _force);
        UpdatedDots(ball.Pos, _force);
    }

    private void OnDragEnd()
    {
        //ball.ActivareRb();
        AtivatedRb();

        ball.Push(_force);

        //trajectory.Hide();
        HidedTrajectory();

        //this.enabled = false;
    }
}
