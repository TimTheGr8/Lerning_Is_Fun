using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio _instance;
    public static Audio Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio is NULL");
            }
            return _instance;
        }
    }
    [SerializeField]
    private AudioSource _musicSource;
    [SerializeField]
    private AudioSource _soundsSource;
    [SerializeField]
    private AudioClip _correctAnswerClip;
    [SerializeField]
    private AudioClip _wrongAnswerClip;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayOneShot(AudioClip clip)
    {
        _soundsSource.PlayOneShot(clip);
    }

    public void PlayCorrectSound()
    {
        _soundsSource.PlayOneShot(_correctAnswerClip);
    }

    public void PlayWrongAnswerSound() 
    {
        _soundsSource.PlayOneShot(_wrongAnswerClip);
    }

    public void SetMusicVolume(float volume)
    {
        _musicSource.volume = volume;
    }
}
