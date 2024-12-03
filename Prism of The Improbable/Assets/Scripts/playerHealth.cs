using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Followed video tutorial: HOW TO MAKE HEART/HEALTH SYSTEM - UNITY TUTORIAL by Blackthornprod
// Video link: https://www.youtube.com/watch?v=3uyolYVsiWc 

public class playerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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
        if (health <= 0)
        {
            GameOverCanvas.instance.TriggerGameOver();
            gameObject.SetActive(false); // Hide player instead of destroying
        }
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Followed youtube video: Unity Player Health and Health bar Tutorial by MoreBBlakeyyy
// Video link: https://www.youtube.com/watch?app=desktop&v=bRcMVkJS3XQ&t=1m53s 

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            GameOverCanvas.instance.TriggerGameOver();
            gameObject.SetActive(false); // Hide player instead of destroying
        }
    }
}*/
