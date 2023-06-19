using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }
    
    public void ExitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
