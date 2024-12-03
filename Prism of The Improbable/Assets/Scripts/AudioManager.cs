using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Followed youtube video: How to Add MUSIC and SOUND EFFECTS ... Tutorial #16 by Rehope Games
// Link: https://www.youtube.com/watch?v=N8whM1GjH4w 

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Soarce --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------- Audio Clip ---------------")]
    public AudioClip background;
    public AudioClip prism;
    public AudioClip door;
    public AudioClip key;
    public AudioClip damage;
    public AudioClip jump;
    public AudioClip recover;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }

    // Play sound effect
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
