using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Window[] _windows;

    private void OnEnable()
    {
        MainWindow.Started += MainWindow_Started;
        MainWindow.OpenedBallsWindow += MainWindow_OpenedBallsWindow;
        BallsWindow.OpenedMaonWindow += BallsWindow_OpenedMaonWindow;
    }

    private void OnDisable()
    {
        MainWindow.Started -= MainWindow_Started;
        MainWindow.OpenedBallsWindow += MainWindow_OpenedBallsWindow;
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
        ShowWindow<BallsWindow>();
    }

    private void BallsWindow_OpenedMaonWindow()
    {
        ShowWindow<MainWindow>();
    }
}