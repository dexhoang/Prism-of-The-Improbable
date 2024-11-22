using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject winCanvas; 
    public GameObject loseCanvas; 
    public GameObject otherMenu; 
    public int requiredKeys = 2; 
    private int keysCollected = 0; 

    // Method to call when a key is collected
    public void CollectKey()
    {
        keysCollected++;
        Debug.Log($"Keys collected: {keysCollected}/{requiredKeys}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (keysCollected >= requiredKeys)
            {
                if (otherMenu != null)
                {
                    otherMenu.SetActive(false);
                }

                winCanvas.SetActive(true);
                Debug.Log("Menu open");
                //Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Not enough keys to open the door!");
                loseCanvas.SetActive(true);
            }
        }
    }
}
