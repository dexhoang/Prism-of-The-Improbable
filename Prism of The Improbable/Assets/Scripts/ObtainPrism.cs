using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used Door trigger and destroy door function from week 2 tutorial as reference

public class ObtainPrism : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;
    [SerializeField] private Color[] prismColors;
    [SerializeField] private Transform player;
    [SerializeField] Vector3 offset = new Vector3(0, 1.5f, 0);

    private int currentColorIndex = 0;
    private bool prismCollected = false;
    private SpriteRenderer prismRenderer;

    private void Start()
    {
        prismRenderer = GetComponent<SpriteRenderer>();
        if (prismRenderer != null && prismColors.Length > 0)
        {
            prismRenderer.color = prismColors[currentColorIndex];
        }
    }

    // Interacting with the prism and changing platform ability
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !prismCollected)
        {
            prismCollected = true;
            SetPlatformProperties(platform[0], "Ground", 1f);
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

        if (prismCollected && Input.GetKeyDown(KeyCode.J))
        {
            ChangePrismColor();
        }
    }

    private void ChangePrismColor()
    {
        currentColorIndex = (currentColorIndex + 1) % prismColors.Length;

        if (prismRenderer != null)
        {
            prismRenderer.color = prismColors[currentColorIndex];
        }

        for (int i = 0; i < platform.Length; i++)
        {
            if (i == currentColorIndex)
            {
                SetPlatformProperties(platform[i], "Ground", 1f);
                Debug.Log($"Platform {i} activated");
            }
            else
            {
                SetPlatformProperties(platform[i], "TransparentPlatform", 0.3f);
                Debug.Log($"Platform {i} deactivated");
            }
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
