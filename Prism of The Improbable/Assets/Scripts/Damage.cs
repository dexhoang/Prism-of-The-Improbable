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
                
                // Update GameManager
                GameManager.instance.SetPlayerHealth(playerHealthComponent.health);
                Debug.Log("Health: " + playerHealthComponent.health);

                // Respawn player to the last checkpoint
                playerg.SetActive(false); 
                //player.position = destination.position;
                playerHealthComponent.Respawn();
                playerg.SetActive(true);

                /*// Teleport player to destination
                playerg.SetActive(false);
                player.position = destination.position;
                playerg.SetActive(true);*/
            }

            // Play damage sound effect
            audioManager.PlaySFX(audioManager.damage);
        }
    }
}
