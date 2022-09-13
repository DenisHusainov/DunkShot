using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : Window
{
    public static event Action OpenedMainWindow = delegate { };
    public static event Action OpenedBallsWindow = delegate { };
    public static event Action OpenedGameWindow = delegate { };
    public static event Action PauseWindowOpenedSettingsWindow = delegate { };

    [SerializeField] private Button _mainWindowButton = null;
    [SerializeField] private Button _ballsWindowButton = null;
    [SerializeField] private Button _resumeWindowButton = null;
    [SerializeField] private Button _settingsButton = null;

    void Start()
    {
        _mainWindowButton.onClick.AddListener(OnMainWindowClicked);
        _ballsWindowButton.onClick.AddListener(OnBallsWindowClicked);
        _resumeWindowButton.onClick.AddListener(OnResumeWindowClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
    }

    private void OnMainWindowClicked()
    {
        OpenedMainWindow();
    }

    private void OnBallsWindowClicked()
    {
        OpenedBallsWindow();
    }

    private void OnResumeWindowClicked()
    {
        OpenedGameWindow();
    }

    private void OnSettingsButtonClicked()
    {
        PauseWindowOpenedSettingsWindow();
    }
}
