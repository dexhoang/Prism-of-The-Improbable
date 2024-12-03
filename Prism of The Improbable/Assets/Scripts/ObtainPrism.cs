using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainPrism : MonoBehaviour
{
    [SerializeField] private Color[] prismColors; // Array of colors for the prism
    [SerializeField] private Transform player;   // Reference to the player

    private int currentColorIndex = 0;
    private bool prismCollected = false;
    private SpriteRenderer prismRenderer;

    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        prismRenderer = GetComponent<SpriteRenderer>();
        if (prismRenderer != null && prismColors.Length > 0)
        {
            prismRenderer.color = prismColors[currentColorIndex];
        }
    }

    // Interacting with the prism
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !prismCollected)
        {
            prismCollected = true;
            Debug.Log("Prism collected, floating above player");

            audioManager.PlaySFX(audioManager.prism);       // play sound effect
        
    
            string targetTag = "PlatformTag" + currentColorIndex;

            GameObject[] activePlatforms = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject platform in activePlatforms)
            {
                SetPlatformProperties(platform, "Ground", 1f);
                Debug.Log($"Activated platform with tag {targetTag}: {platform.name}");
            }
        }
    }

    // Update method for floating prism and changing platform properties
    private void Update()
    {
        if (prismCollected && player != null)
        {
            // Make the prism float above the player
            transform.position = player.position + new Vector3(0, 0.8f, 0);
        }

        if (prismCollected && Input.GetMouseButtonDown(0))
        {
            ChangePrismColor(-1); // Left mouse click for the previous color
            Debug.Log("Left mouse button clicked, changing to previous color");
        }

        if (prismCollected && Input.GetMouseButtonDown(1))
        {
            ChangePrismColor(1); // Right mouse click for the next color
            Debug.Log("Right mouse button clicked, changing to next color");
        }
    }

    // Changes the color of the prism and updates platform properties
    private void ChangePrismColor(int direction)
    {
        // Calculate the new color index
        currentColorIndex = (currentColorIndex + direction + prismColors.Length) % prismColors.Length;

        if (prismRenderer != null)
        {
            prismRenderer.color = prismColors[currentColorIndex];
        }

        // Tag for the current color index
        string targetTag = "PlatformTag" + currentColorIndex; // Example: PlatformTag0, PlatformTag1, etc.

        // Activate platforms with the target tag
        GameObject[] activePlatforms = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject platform in activePlatforms)
        {
            SetPlatformProperties(platform, "Ground", 1f);
            Debug.Log($"Activated platform with tag {targetTag}: {platform.name}");
        }

        // Deactivate platforms with other tags
        for (int i = 0; i < prismColors.Length; i++)
        {
            if (i != currentColorIndex)
            {
                string otherTag = "PlatformTag" + i; // Other tags
                GameObject[] inactivePlatforms = GameObject.FindGameObjectsWithTag(otherTag);
                foreach (GameObject platform in inactivePlatforms)
                {
                    SetPlatformProperties(platform, "TransparentPlatform", 0.3f);
                    Debug.Log($"Deactivated platform with tag {otherTag}: {platform.name}");
                }
            }
        }
    }

    // Sets the layer and transparency for a platform
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

 