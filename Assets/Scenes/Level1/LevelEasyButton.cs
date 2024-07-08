using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this line

public class LevelEasyButton : MonoBehaviour
{
    public GameObject pausePanel;
    public SoundManager soundManager;
    public Button muteButton;
    public Sprite soundOnSprite; // Image when sound is on
    public Sprite soundOffSprite; // Image when sound is off
    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel GameObject is not assigned!");
        }

        UpdateMuteButtonImage();
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void GoToLevel2Easy()
    {
        SceneManager.LoadScene("LevelEasy2");
    }

    public void GoToLevel3Easy()
    {
        SceneManager.LoadScene("LevelEasy3");
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }

    public void ToggleMuteBGM()
    {
        if (soundManager != null)
        {
            soundManager.ToggleMute();
            UpdateMuteButtonImage();
        }
    }

    private void UpdateMuteButtonImage()
    {
        if (muteButton != null && soundOnSprite != null && soundOffSprite != null)
        {
            if (soundManager.IsMuted())
            {
                muteButton.image.sprite = soundOffSprite;
            }
            else
            {
                muteButton.image.sprite = soundOnSprite;
            }
        }
    }
}
