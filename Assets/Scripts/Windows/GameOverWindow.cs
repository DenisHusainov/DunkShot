using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : Window
{
    public static event Action GameRestarted = delegate { };

    [SerializeField] private Button _restartButton = null;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        GameRestarted();
    }

}
