using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public GameObject overCanvas;
    public GameObject otherMenu;

    public static GameOverCanvas instance;

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

    public void TriggerGameOver()
    {
        if (otherMenu != null)
        {
            otherMenu.SetActive(false);
        }

        overCanvas.SetActive(true);
        Debug.Log("Game Over");
        Time.timeScale = 0f; // Pause the game
    }
}
