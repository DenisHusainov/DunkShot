using System;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : Window
{
    public static event Action Started = delegate { };
    public static event Action OpenedBallsWindow = delegate { };
    public static event Action MainWindowOpenedSettingsWindow = delegate { };
    public static event Action ChangedDarkMode = delegate { };

    [SerializeField] private Button _startGameButton = null;
    [SerializeField] private Button _changeBallsButton = null;
    [SerializeField] private Button _changeLightButton = null;
    [SerializeField] private Button _settingsButton = null;

    private void Start()
    {
        
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        _changeBallsButton.onClick.AddListener(OnChangeBallsButtonClicked);
        _changeLightButton.onClick.AddListener(OnChangeLightButtonClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
    }

    private void OnStartGameButtonClicked()
    {
        Started();
    }

    private void OnChangeBallsButtonClicked()
    {
        OpenedBallsWindow();
    }

    private void OnChangeLightButtonClicked()
    {
        ChangedDarkMode();
    }

    private void OnSettingsButtonClicked()
    {
        MainWindowOpenedSettingsWindow();
    }
}