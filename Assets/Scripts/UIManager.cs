using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Window[] _windows;

    public static bool isPaused { get; private set; }

    private void OnEnable()
    {
        MainWindow.Started += MainWindow_Started;
        MainWindow.OpenedBallsWindow += MainWindow_OpenedBallsWindow;
        MainWindow.OpenedSettingsWindow += MainWindow_OpenedSettingsWindow;
        BallsWindow.OpenedMainWindow += BallsWindow_OpenedMainWindow;
        GameWindow.OpenedPauseWindow += GameWindow_OpenedPauseWindow;
        PauseWindow.OpenedMainWindow += PauseWindow_OpenedMainWindow;
        PauseWindow.OpenedBallsWindow += PauseWindow_OpenedBallsWindow;
        PauseWindow.OpenedGameWindow += PauseWindow_OpenedGameWindow;

    }

    private void OnDisable()
    {
        MainWindow.Started -= MainWindow_Started;
        MainWindow.OpenedBallsWindow -= MainWindow_OpenedBallsWindow;
        MainWindow.OpenedSettingsWindow -= MainWindow_OpenedSettingsWindow;
        BallsWindow.OpenedMainWindow -= BallsWindow_OpenedMainWindow;
        GameWindow.OpenedPauseWindow -= GameWindow_OpenedPauseWindow;
        PauseWindow.OpenedMainWindow -= PauseWindow_OpenedMainWindow;
        PauseWindow.OpenedBallsWindow -= PauseWindow_OpenedBallsWindow;
        PauseWindow.OpenedGameWindow -= PauseWindow_OpenedGameWindow;

    }

    private void Awake()
    {
        _windows = GetComponentsInChildren<Window>();
        ShowWindow<MainWindow>();
        DontDestroyOnLoad(gameObject);
    }

    private void CloseWindows()
    {
        foreach (var window in _windows)
        {
            window.Close();
        }
    }

    private void ShowWindow<T>() where T : Window
    {
        CloseWindows();
        var windowToShow = _windows.FirstOrDefault(x => x is T);
        windowToShow.Show();
    }

    private void MainWindow_Started()
    {
        ShowWindow<GameWindow>();
    }

    private void MainWindow_OpenedBallsWindow()
    {
        isPaused = false;
        ShowWindow<BallsWindow>();
    }

    private void BallsWindow_OpenedMainWindow()
    {
        if (!isPaused)
        {
            ShowWindow<MainWindow>();
        }
        else
        {
            ShowWindow<PauseWindow>();
        }
    }

    private void GameWindow_OpenedPauseWindow()
    {
        ShowWindow<PauseWindow>();
    }

    private void PauseWindow_OpenedMainWindow()
    {
        ShowWindow<MainWindow>();
    }

    private void PauseWindow_OpenedBallsWindow()
    {
        isPaused = true;
        ShowWindow<BallsWindow>();
    }

    private void PauseWindow_OpenedGameWindow()
    {
        ShowWindow<GameWindow>();
    }

    private void MainWindow_OpenedSettingsWindow()
    {
        ShowWindow<SettingsWindow>();
    }
}