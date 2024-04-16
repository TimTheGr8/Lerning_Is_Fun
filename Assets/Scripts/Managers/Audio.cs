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
    AudioSource _musicSource;
    [SerializeField]
    AudioSource _soundsSource;
    [SerializeField]
    AudioClip _currentAudioClip;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayOneShot()
    {
        _soundsSource.PlayOneShot(_currentAudioClip);
    }
}
