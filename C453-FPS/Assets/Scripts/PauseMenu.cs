using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public static PauseMenu instance;

    public bool isPaused;

    public void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            if (!pauseMenu.activeSelf)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
