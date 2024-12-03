using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Followed youtube video: Unity Player Health and Health bar Tutorial by MoreBBlakeyyy
// Video link: https://www.youtube.com/watch?app=desktop&v=bRcMVkJS3XQ&t=1m53s 

public class Damage : MonoBehaviour
{
    public playerHealth pHealth;
    public Transform player, destination;
    public GameObject playerg;
    public int damage; // Changed from float to int

    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Decrease health
            playerHealth playerHealthComponent = other.gameObject.GetComponent<playerHealth>();
            if (playerHealthComponent != null)
            {
                playerHealthComponent.health -= damage;
            }

            // Teleport player to destination
            playerg.SetActive(false);
            player.position = destination.position;
            playerg.SetActive(true);

            // Play damage sound effect
            audioManager.PlaySFX(audioManager.damage);
        }
    }
}
