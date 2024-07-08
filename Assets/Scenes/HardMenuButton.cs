using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardMenuButton : MonoBehaviour
{
    // Load the scene named "LevelHard1" with a 600ms delay
    public void GoToLevelHard1()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelHard1", 0.6f));
    }

    // Load the scene named "LevelHard2" with a 600ms delay
    public void GoToLevelHard2()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelHard2", 0.6f));
    }

    // Load the scene named "LevelHard3" with a 600ms delay
    public void GoToLevelHard3()
    {
        StartCoroutine(LoadSceneAfterDelay("LevelHard3", 0.6f));
    }

    // Coroutine to load a scene after a delay
    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
