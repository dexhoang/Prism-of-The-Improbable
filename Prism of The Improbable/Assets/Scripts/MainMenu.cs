using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

// I followed the tutorial video for the entire code: https://www.youtube.com/watch?v=DX7HyN7oJjE 
// Make Your MAIN MENU Quickly! | Unity UI Tutorial For Beginners by Rehope Games
public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void MenuScene() 
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            // If running in the editor, stop play mode
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // If running as a standalone application, quit the application
            Application.Quit();
        #endif
    }
}