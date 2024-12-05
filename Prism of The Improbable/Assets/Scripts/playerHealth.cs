using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Followed video tutorial: HOW TO MAKE HEART/HEALTH SYSTEM - UNITY TUTORIAL by Blackthornprod
// Video link: https://www.youtube.com/watch?v=3uyolYVsiWc 

// Followed youtube video: Unity Player Health and Health bar Tutorial by MoreBBlakeyyy
// Video link: https://www.youtube.com/watch?app=desktop&v=bRcMVkJS3XQ&t=1m53s 

public class playerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Vector3 respawnPosition;

    private void Start()
    {
        // Initialize health and max hearts from the GameManager
        health = GameManager.instance.GetPlayerHealth();
        numOfHearts = GameManager.instance.numOfHearts;

        // Set initial respawn position to the player's starting position
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure health doesn't exceed the maximum number of hearts
        health = Mathf.Clamp(health, 0, numOfHearts);

        // Update hearts UI
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Show or hide hearts based on numOfHearts
            hearts[i].enabled = i < numOfHearts;
        }

        // Check if the player is out of health
        // If so, then set player as inactive 
        if (health <= 0)
        {
            GameOverCanvas.instance.TriggerGameOver();
            gameObject.SetActive(false);
        }

        // Synchronize health with the GameManager
        GameManager.instance.SetPlayerHealth(health);
    }

    public void SetRespawnPosition(Vector3 newPosition)
    {
        respawnPosition = newPosition;
    }

    public void Respawn()
    {
        // Reset the player's position to the last checkpoint
        transform.position = respawnPosition;
        health = health;
        health = GameManager.instance.GetPlayerHealth();
    }

} 
