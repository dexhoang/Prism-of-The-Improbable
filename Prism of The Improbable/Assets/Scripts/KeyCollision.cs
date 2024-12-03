using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour
{
    private int keyCount;

    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected a key!");
            WinLoseScreen.instance.CollectKey(); // Notify WinLoseScreen
            gameObject.SetActive(false); 

            audioManager.PlaySFX(audioManager.key);       // play sound effect
        }
    }
}
 