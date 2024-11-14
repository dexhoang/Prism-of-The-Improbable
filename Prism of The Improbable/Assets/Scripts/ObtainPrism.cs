using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used Door trigger and destroy door function from week 2 tutorial as reference

public class ObtainPrism : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject coloredPlatform; 

    public Transform player;  
    public Vector3 offset = new Vector3(0, 1.5f, 0);  
    private bool prismCollected = false; 

    // Interacting with the prism and changing platform ability
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetPlatformProperties(coloredPlatform, "Ground", 1f);  // Fully opaque, solid layer
            Debug.Log("Solid platform activated and opaque!");

            SetPlatformProperties(platform, "TransparentPlatform", 0.3f); // Semi-transparent, non-collidable layer
            Debug.Log("Transparent platform deactivated!");

            prismCollected = true;
            Debug.Log("Prism collected, floating above player");

        }
    }

    // Should make the prism float on top of the player if the player did interact with the prism
    void Update()
    {
        if (prismCollected && player != null)
        {
            transform.position = player.position + offset;
        }
    }


    // I used ChatGPT for how to make the platforms switch between layers of solid and trasparency
    // It suggested making a solidPlatform layer and a transparentPlatform layer
    // And it provided this function code for setting platform layer and opacity
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
