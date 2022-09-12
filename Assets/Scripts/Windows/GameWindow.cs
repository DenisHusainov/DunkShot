using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameWindow : Window
{
    public static event Action OpenedPauseWindow = delegate { }; 

    [SerializeField] private TextMeshProUGUI _score = null;
    [SerializeField] private Button _pauseButton = null;

    private static int _countPoint = default;

    private void OnEnable()
    {
        HoopSpawner.BallFlew += HoopSpawner_BallFlew;
    }

    private void OnDisable()
    {
        HoopSpawner.BallFlew -= HoopSpawner_BallFlew;
    }

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }

    private void OnPauseButtonClicked()
    {
        OpenedPauseWindow();
    }

    private void HoopSpawner_BallFlew()
    {
        _countPoint++;
        _score.text = _countPoint.ToString();
    }
}