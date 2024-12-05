using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject winCanvas; 
    public GameObject loseCanvas; 
    public GameObject otherMenu; 
    public int requiredKeys;
    private int keysCollected = 0; 

    public static WinLoseScreen instance; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increment the keys collected
    public void CollectKey()
    {
        keysCollected++;
        Debug.Log($"Keys collected: {keysCollected}/{requiredKeys}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (keysCollected == requiredKeys)
            {
                // Player has enough keys
                if (otherMenu != null)
                {
                    otherMenu.SetActive(false);
                }

                winCanvas.SetActive(true); 
                Debug.Log("Player wins!");
                // Time.timeScale = 0f; 
            }
            else
            {
                // Player doesn't have enough keys
                loseCanvas.SetActive(true); 
                Debug.Log("Not enough keys! Player loses.");
            }
        }
    }
}
