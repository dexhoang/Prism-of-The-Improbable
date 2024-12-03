using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject otherMenu; 
    public GameObject player; 
    public GameObject prism; 

    private bool isPaused = false;

    void Start()
    {
        PauseCanvas.SetActive(false); // Ensure the pause menu is hidden initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerPauseMenu();
        }
    }

    public void TriggerPauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Activate pause menu and freeze the game
            PauseCanvas.SetActive(true);
            if (otherMenu != null) otherMenu.SetActive(false);
            if (prism != null) prism.SetActive(false);
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            // Deactivate pause menu and resume the game
            PauseCanvas.SetActive(false);
            if (otherMenu != null) otherMenu.SetActive(true);
            if (prism != null) prism.SetActive(true);
            Time.timeScale = 1f; // Resume the game
        }

        Debug.Log("Pause Toggled: " + isPaused);
    }
}

