using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Button contineuButton, respawnButton, exitGameButton;

    void Start()
    {
        contineuButton.onClick.AddListener(ContinueGame);
        respawnButton.onClick.AddListener(Respawn);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    void ContinueGame()
    {
        // Unpause Game
    }

    void Respawn()
    {
        SceneManager.LoadScene("MainScene");
    }

    void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
