using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainPrism : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject coloredPlatform; 

    public Transform player;  
    public Vector3 offset = new Vector3(0, 1.5f, 0);  
    private bool prismCollected = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the platform solid and enable it
            coloredPlatform.SetActive(true);
            SetPlatformProperties(coloredPlatform, "Ground", 1f);  // Fully opaque, solid layer
            Debug.Log("Solid platform activated and opaque!");

            // Make the original platform transparent and disable collisions
            SetPlatformProperties(platform, "TransparentPlatform", 0.3f); // Semi-transparent, non-collidable layer
            Debug.Log("Transparent platform deactivated!");

            // Set prism position above player
            prismCollected = true;
            Debug.Log("Prism collected, floating above player");

        }
    }

    private void Update()
    {
        // If the prism has been collected, position it above the player's head
        if (prismCollected && player != null)
        {
            transform.position = player.position + offset;
        }
    }

    // Helper method to set platform layer and opacity
    private void SetPlatformProperties(GameObject platformObject, string layerName, float alpha)
    {
        platformObject.layer = LayerMask.NameToLayer(layerName);
        
        SpriteRenderer sr = platformObject.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color color = sr.color;
            color.a = alpha;
            sr.color = color;
        }
    }
}
