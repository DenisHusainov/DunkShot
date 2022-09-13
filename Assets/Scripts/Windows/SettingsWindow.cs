using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : Window
{
    public static event Action SettingsReturnedWindow = delegate { };

    [SerializeField] private Button _backButton = null;

    private void Start()
    {
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked()
    {
        SettingsReturnedWindow();
    }
}
