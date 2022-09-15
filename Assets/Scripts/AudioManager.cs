using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private AudioClip _hitSound = null;
    [SerializeField] private AudioClip _ballFlewInSound = null;
    [SerializeField] private AudioClip _reboundSound = null;

    private void OnEnable()
    {
        HoopSpawner.BallFlewIn += HoopSpawner_BallFlewIn;
        Ball.BallFlewOut += Ball_BallFlewOut;
    }

    private void OnDisable()
    {
        HoopSpawner.BallFlewIn -= HoopSpawner_BallFlewIn;
        Ball.BallFlewOut -= Ball_BallFlewOut;
    }

    private void PlayAudio(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    private void ReboundSound()
    {
        PlayAudio(_reboundSound);
    }

    private void HoopSpawner_BallFlewIn()
    {
        PlayAudio(_ballFlewInSound);
    }

    private void Ball_BallFlewOut()
    {
        PlayAudio(_hitSound);
    }
}
