using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour
{
    public GameObject[] objectsToDrag;
    public GameObject[] objectsDragToPos;

    public int dropDistance;
    public GameObject panelGameObject;

    [SerializeField] private AudioSource dragSoundSource;
    [SerializeField] private AudioSource dropSoundSource;
    [SerializeField] private AudioSource wrongDropSoundSource;
    public AudioClip dragSound;
    public AudioClip dropSound;
    public AudioClip wrongDropSound;

    [SerializeField] private AudioSource completeSoundSource;
    public AudioClip completeSound;
    private int itemsDroppedCount = 0;
    private Vector3[] objectsInitPos;
    private bool[] dragSoundPlayed;

    // Reference to SoundManager
    public SoundManager soundManager;

    void Start()
    {
        // Deactivate the panel GameObject at the start
        if (panelGameObject != null)
        {
            panelGameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel GameObject is not assigned!");
        }

        // Initialize object positions and drag sound flags
        objectsInitPos = new Vector3[objectsToDrag.Length];
        dragSoundPlayed = new bool[objectsToDrag.Length];
        for (int i = 0; i < objectsToDrag.Length; i++)
        {
            objectsInitPos[i] = objectsToDrag[i].transform.localPosition;
            dragSoundPlayed[i] = false;
        }

        // Find SoundManager if not assigned
        if (soundManager == null)
        {
            soundManager = FindObjectOfType<SoundManager>();
        }

        if (soundManager == null)
        {
            Debug.LogWarning("SoundManager is not assigned and could not be found in the scene!");
        }
    }

    public void DragObject(int number)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = objectsToDrag[number].transform.position.z; // Maintain the original Z position
        objectsToDrag[number].transform.position = newPosition;

        // Play drag sound only once when initially picked up
        if (!dragSoundPlayed[number] && dragSound != null)
        {
            dragSoundSource.PlayOneShot(dragSound);
            dragSoundPlayed[number] = true; // Set the flag to true to indicate that the sound has been played
        }
    }

    public void DropObject(int number)
    {
        float distance = Vector3.Distance(objectsToDrag[number].transform.localPosition, objectsDragToPos[number].transform.localPosition);

        if (distance < dropDistance)
        {
            objectsToDrag[number].transform.localPosition = objectsDragToPos[number].transform.localPosition;
            itemsDroppedCount++;

            // Play drop sound
            if (dropSoundSource != null && dropSound != null)
            {
                dropSoundSource.PlayOneShot(dropSound);
            }
        }
        else
        {
            objectsToDrag[number].transform.localPosition = objectsInitPos[number];

            // Play wrong drop sound
            if (wrongDropSoundSource != null && wrongDropSound != null)
            {
                wrongDropSoundSource.PlayOneShot(wrongDropSound);
            }

            // Reset drag sound flag when item is returned to initial position
            dragSoundPlayed[number] = false;
        }

        if (itemsDroppedCount == objectsToDrag.Length)
        {
            StartCoroutine(ShowPanelWithDelay(1f)); // Start coroutine with a 1-second delay
        }
    }

    IEnumerator ShowPanelWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (panelGameObject != null)
        {
            panelGameObject.SetActive(true);
            Time.timeScale = 0f; // Stop the game when the panel is shown

            // Stop the background music
            if (soundManager != null)
            {
                soundManager.StopBGM();
            }

            // Play the complete sound
            if (completeSoundSource != null && completeSound != null)
            {
                completeSoundSource.PlayOneShot(completeSound);
            }
        }
    }

    void OnDisable()
    {
        Time.timeScale = 1f; // Ensure the game resumes if this script is disabled
    }
}