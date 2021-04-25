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
        exitGameButton.onClick.AddListener(ExitGame);
    }

    void ContinueGame()
    {
        pauseMenu.GetComponent<Canvas>().sortingOrder = 0;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void ExitGame()
    {
        pauseMenu.GetComponent<Canvas>().sortingOrder = 0;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
