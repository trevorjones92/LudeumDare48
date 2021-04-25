using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Button contineuButton, respawnButton, exitGameButton;
    public GameObject pauseMenu;

    void Start()
    {
        contineuButton.onClick.AddListener(ContinueGame);
        respawnButton.onClick.AddListener(Respawn);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    void ContinueGame()
    {
        pauseMenu.GetComponent<Canvas>().sortingOrder = 0;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
