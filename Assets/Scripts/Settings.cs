using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Slider _masterVolumeSlider;
    [SerializeField]
    private Slider _soundAudioSlider;
    [SerializeField]
    private Slider _brightnessSlider;
    [SerializeField]
    private Image _overlayImage;
    [SerializeField]
    private AudioMixer _mixer;

    public void AdjustBrightness()
    {
        var tempColor = _overlayImage.color;
        tempColor.a = _brightnessSlider.value;
        _overlayImage.color = tempColor;
    }

    public void AdjustMasterVolume()
    {
        _mixer.SetFloat("MasterAudio", _masterVolumeSlider.value);
    }

    public void AdjustSoundVolume()
    {
        _mixer.SetFloat("SoundAudio", _soundAudioSlider.value);
    }
}
