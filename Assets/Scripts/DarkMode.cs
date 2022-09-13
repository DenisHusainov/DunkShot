using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMode : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Color _darkMode = default;
    private Color _lightMode = default;
    private bool _isDarkMode = default;

    private void OnEnable()
    {
        MainWindow.ChangedDarkMode += MainWindow_ChangedDarkMode;
    }

    private void OnDisable()
    {
        MainWindow.ChangedDarkMode -= MainWindow_ChangedDarkMode;
    }

    private void Start()
    {
        _darkMode = new Color(0.5f, 0.5f, 0.5f, 1f);
        _lightMode = new Color(0.8941177f, 0.8980392f, 0.7333333f, 1f);
    }

    private void ChengeDarkMode()
    {
        if (!_isDarkMode)
        {
            _camera.backgroundColor = _darkMode;
            _isDarkMode = true;
        }
        else
        {
            _camera.backgroundColor = _lightMode;
            _isDarkMode = false;
        }
    }

    private void MainWindow_ChangedDarkMode()
    {
        ChengeDarkMode();
    }
}
