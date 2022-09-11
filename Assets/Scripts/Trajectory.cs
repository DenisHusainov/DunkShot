using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int _dotsNumber;
    [SerializeField] private GameObject _dotsParent;
    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private float _dotSpacing;
    [SerializeField] [Range(0.1f, 0.3f)] private float _dotMinScale;
    [SerializeField] [Range(0.3f, 1f)] private float _dotMaxScale;

    private Vector2 _dotPos;
    private float _timeStamp;

    private Transform[] _dotsList;

    private void OnEnable()
    {
        InputManager.ShowedTrajectory += InputManager_ShowedTrajectory;
        InputManager.HidedTrajectory += InputManager_HidedTrajectory;
        InputManager.UpdatedDots += InputManager_UpdatedDots;
    }

    private void OnDisable()
    {
        InputManager.ShowedTrajectory -= InputManager_ShowedTrajectory;
        InputManager.HidedTrajectory -= InputManager_HidedTrajectory;
        InputManager.UpdatedDots -= InputManager_UpdatedDots;
    }

    private void Start()
    {
        Hide();
        PrepareDots();
    }

    private void PrepareDots()
    {
        _dotsList = new Transform[_dotsNumber];
        _dotPrefab.transform.localScale = Vector3.one * _dotMaxScale;

        float scale = _dotMaxScale;
        float scaleFactor = scale / _dotsNumber;
        for (int i = 0; i < _dotsNumber; i++)
        {
            _dotsList[i] = Instantiate(_dotPrefab, null).transform;
            _dotsList[i].parent = _dotsParent.transform;

            _dotsList[i].localScale = Vector3.one * scale;
            if (scale > _dotMinScale)
            {
                scale -= scaleFactor;
            }
        }
    }

    private void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        _timeStamp = _dotSpacing;
        for (int i = 0; i < _dotsNumber; i++)
        {
            _dotPos.x = (ballPos.x + forceApplied.x * _timeStamp);
            _dotPos.y = (ballPos.y + forceApplied.y * _timeStamp)
                - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2f;
            _dotsList[i].position = _dotPos;
            _timeStamp += _dotSpacing;
        }
    }

    private void Show()
    {
        _dotsParent.SetActive(true);
    }

    private void Hide()
    {
        _dotsParent.SetActive(false);
    }

    private void InputManager_UpdatedDots(Vector3 ballPos, Vector2 forceApplied)
    {
        UpdateDots(ballPos, forceApplied);
    }

    private void InputManager_HidedTrajectory()
    {
        Hide();
    }

    private void InputManager_ShowedTrajectory()
    {
        Show();
    }
}
