using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // Load the scene named "DifficultyMenu" with a 5/6 second delay
    public void GoToDifficultyMenu()
    {
        StartCoroutine(LoadSceneAfterDelay("DifficultyMenu", 0.600f));
    }


    public void goToInfo() 
    {
        SceneManager.LoadScene("Info");
    }

    // Quit the application
    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Application has been quit."); // This line is for debug purposes in the editor
    }

    // Coroutine to load a scene after a delay
    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
