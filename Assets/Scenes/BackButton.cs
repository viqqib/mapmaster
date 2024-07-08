using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void backToMainMenu() 
    {
        SceneManager.LoadScene("Main");
    }
    public void backToDiffnMenu() 
    {
        SceneManager.LoadScene("DifficultyMenu");
    }
    public void GoBack()
    {
        // Check if there's a previous scene in the scene history
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            // Load the previous scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            Debug.LogWarning("There's no previous scene to go back to.");
        }
    }
}
