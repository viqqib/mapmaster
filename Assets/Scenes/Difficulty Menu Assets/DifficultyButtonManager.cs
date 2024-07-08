using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButtonManager : MonoBehaviour
{
    // Load the scene named "LevelEasy" with a 600ms delay
    public void GoToLevelEasy()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelEasy", 0.6f));
    }

    // Load the scene named "LevelHard" with a 600ms delay
    public void GoToLevelHard()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelHard", 0.6f));
    }

    // Coroutine to load a scene after a delay
    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
