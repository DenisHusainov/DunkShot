using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : Window
{
    public static event Action OpenedMainWindow = delegate { };
    public static event Action OpenedBallsWindow = delegate { };
    public static event Action OpenedGameWindow = delegate { };

    [SerializeField] Button _mainWindowButton = null;
    [SerializeField] Button _ballsWindowButton = null;
    [SerializeField] Button _resumeWindowButton = null;

    void Start()
    {
        _mainWindowButton.onClick.AddListener(OnMainWindowClicked);
        _ballsWindowButton.onClick.AddListener(OnBallsWindowClicked);
        _resumeWindowButton.onClick.AddListener(OnResumeWindowClicked);
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
}
