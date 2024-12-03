using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainPrism : MonoBehaviour
{
    [SerializeField] private Sprite[] prismSprites; // Array of sprites for the prism
    [SerializeField] private Transform player;     // Reference to the player

    private int currentSpriteIndex = 0;
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
        if (prismRenderer != null && prismSprites.Length > 0)
        {
            prismRenderer.sprite = prismSprites[currentSpriteIndex];
        }
    }

    // Interacting with the prism
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !prismCollected)
        {
            prismCollected = true;
            Debug.Log("Prism collected, floating above player");

            audioManager.PlaySFX(audioManager.prism);

            string targetTag = "PlatformTag" + currentSpriteIndex;

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

        // Changes to previous sprite when left click/J is pressed, next sprite when right/K is pressed
        if (prismCollected && Input.GetMouseButtonDown(0))
        {
            ChangePrismSprite(-1);
            audioManager.PlaySFX(audioManager.prism);
        }

        if (prismCollected && Input.GetKeyDown(KeyCode.J))
        {
            ChangePrismSprite(-1);
            audioManager.PlaySFX(audioManager.prism);
        }

        if (prismCollected && Input.GetMouseButtonDown(1))
        {
            ChangePrismSprite(1);
            audioManager.PlaySFX(audioManager.prism);
        }

        if (prismCollected && Input.GetKeyDown(KeyCode.K))
        {
            ChangePrismSprite(1);
            audioManager.PlaySFX(audioManager.prism);
        }
    }

    // Changes the sprite of the prism and updates platform properties
    private void ChangePrismSprite(int direction)
    {
        // Calculate the new sprite index
        currentSpriteIndex = (currentSpriteIndex + direction + prismSprites.Length) % prismSprites.Length;

        if (prismRenderer != null)
        {
            prismRenderer.sprite = prismSprites[currentSpriteIndex];
        }

        // Tag for the current sprite index
        string targetTag = "PlatformTag" + currentSpriteIndex;

        // Activate platforms with the target tag
        GameObject[] activePlatforms = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject platform in activePlatforms)
        {
            SetPlatformProperties(platform, "Ground", 1f);
            Debug.Log($"Activated platform with tag {targetTag}: {platform.name}");
        }

        // Deactivate platforms with other tags
        for (int i = 0; i < prismSprites.Length; i++)
        {
            if (i != currentSpriteIndex)
            {
                string otherTag = "PlatformTag" + i;
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
