using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Followed video tutorial as reference: How To Make A Volume Slider In 4 Minutes - Easy Unity Tutorial by Hooson
// Video link: https://www.youtube.com/watch?v=yWCHaTwVblk 

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectsSlider;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioSource> soundEffectsSources;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        if (!PlayerPrefs.HasKey("soundEffectsVolume"))
        {
            PlayerPrefs.SetFloat("soundEffectsVolume", 1);
        }

        Load();
    }

    public void ChangeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
        Save();
    }

    public void ChangeSoundEffectsVolume()
    {
        foreach (var soundEffect in soundEffectsSources)
        {
            soundEffect.volume = soundEffectsSlider.value;
        }
        Save();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundEffectsSlider.value = PlayerPrefs.GetFloat("soundEffectsVolume");

        musicSource.volume = musicSlider.value;
        foreach (var soundEffect in soundEffectsSources)
        {
            soundEffect.volume = soundEffectsSlider.value;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsSlider.value);
    }
}

 