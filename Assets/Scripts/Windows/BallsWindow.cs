using System;
using UnityEngine;
using UnityEngine.UI;

public class BallsWindow : Window
{
    public static event Action BallsReturnedWindow = delegate { };

    [SerializeField] private Button _backButton = null;

    private void Start()
    {
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked()
    {
        BallsReturnedWindow();
    }
}
