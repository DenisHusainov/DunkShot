using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameWindow : Window
{
    public static event Action OpenedPauseWindow = delegate { }; 

    [SerializeField] private TextMeshProUGUI _score = null;
    [SerializeField] private Button _pauseButton = null;

    private int _countPoint = default;

    private void OnEnable()
    {
        HoopSpawner.BallFlewIn += HoopSpawner_BallFlewIn;
    }

    private void OnDisable()
    {
        HoopSpawner.BallFlewIn -= HoopSpawner_BallFlewIn;
    }

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }

    private void OnPauseButtonClicked()
    {
        OpenedPauseWindow();
    }

    private void HoopSpawner_BallFlewIn()
    {
        _countPoint++;
        _score.text = _countPoint.ToString();
    }
}