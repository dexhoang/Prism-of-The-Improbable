using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpointPosition; // Position to respawn the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Update player's respawn position
            playerHealth playerHealthComponent = other.GetComponent<playerHealth>();
            if (playerHealthComponent != null)
            {
                playerHealthComponent.SetRespawnPosition(checkpointPosition.position);
            }

            Debug.Log("Checkpoint updated!");
        }
    }
}

