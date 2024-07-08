using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyMenuButton : MonoBehaviour
{
    // Load the scene named "LevelEasy1" with a 600ms delay
    public void GoToLevelEasy1()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelEasy1", 0.6f));
    }

    // Load the scene named "LevelEasy2" with a 600ms delay
    public void GoToLevelEasy2()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelEasy2", 0.6f));
    }

    // Load the scene named "LevelEasy3" with a 600ms delay
    public void GoToLevelEasy3()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelEasy3", 0.6f));
    }

    // Coroutine to load a scene after a delay
    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
