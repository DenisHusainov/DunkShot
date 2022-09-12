using UnityEngine;
using TMPro;

public class GameWindow : Window
{
    [SerializeField] private TextMeshProUGUI _score = null;

    private static int _countPoint = default;

    private void OnEnable()
    {
        HoopSpawner.BallFlew += HoopSpawner_BallFlew;
    }

    private void OnDisable()
    {
        HoopSpawner.BallFlew -= HoopSpawner_BallFlew;
    }

    private void HoopSpawner_BallFlew()
    {
        _countPoint++;
        _score.text = _countPoint.ToString();
    }
}