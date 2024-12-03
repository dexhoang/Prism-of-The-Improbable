using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Followed youtube video: Unity Player Health and Health bar Tutorial by MoreBBlakeyyy
// Video link: https://www.youtube.com/watch?app=desktop&v=bRcMVkJS3XQ&t=1m53s 

public class Damage : MonoBehaviour
{
    public playerHealth pHealth;
    public GameObject playerg; 
    public int damage; 

    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the player's health component
            playerHealth playerHealthComponent = other.gameObject.GetComponent<playerHealth>();
            if (playerHealthComponent != null)
            {
                // Decrease player's health
                playerHealthComponent.health -= damage;

                // Respawn player to the last checkpoint
                playerg.SetActive(false); // Optionally disable player object for visual feedback
                playerHealthComponent.Respawn();
                playerg.SetActive(true); // Reactivate player object
            }

            // Play damage sound effect
            audioManager.PlaySFX(audioManager.damage);
        }
    }
}
