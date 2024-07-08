using UnityEngine;
using TMPro;

public class CountdownTimer20 : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject timerOutPanel; // Reference to the panel to show when time is run out
    private float timeRemaining = 20f;
    private bool isCounting = false;
    private bool isGameRunning = true;

    [SerializeField] private AudioSource timeoutSoundSource; // Reference to the AudioSource
    [SerializeField] private AudioSource tickSoundSource; // Reference to the tick sound AudioSource
    public AudioClip timeoutSound; // Reference to the AudioClip for the timeout sound
    public AudioClip tickSound;

    // Reference to the SoundManager script
    private SoundManager soundManager;

    void Start()
    {
        // Find and assign the SoundManager script in the scene
        soundManager = FindObjectOfType<SoundManager>();
        InitializeTimer();
    }

    void Update()
    {
        if (isCounting && isGameRunning)
        {
            // Update the countdown timer
            timeRemaining -= Time.deltaTime;
            UpdateCountdownText();

            // Check if time has run out
            if (timeRemaining <= 0f)
            {
                // Time's up!
                timeRemaining = 0f;
                isCounting = false;
                isGameRunning = false;
                HandleTimeOut();
            }
            // Check if there are 10 seconds left and play the tick sound
            else if (timeRemaining <= 10f && !tickSoundSource.isPlaying && !timerOutPanel.activeSelf)
            {
                if (tickSoundSource != null && tickSound != null)
                {
                    tickSoundSource.PlayOneShot(tickSound);
                }
            }
        }
    }

    void StartCountdown()
    {
        isCounting = true;
    }

    void HandleTimeOut()
    {
        UpdateCountdownText();
        
        // Activate the timer out panel
        if (timerOutPanel != null)
        {
            timerOutPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Timer Out Panel GameObject is not assigned!");
        }
        
        // Play the timeout sound
        if (timeoutSoundSource != null && timeoutSound != null)
        {
            timeoutSoundSource.PlayOneShot(timeoutSound);
        }
        else
        {
            Debug.LogWarning("Timeout sound or AudioSource is not assigned!");
        }

        // Stop the background music (call StopBGM from SoundManager)
        if (soundManager != null)
        {
            soundManager.StopBGM();
        }

        // Stop the tick sound if it's playing
        if (tickSoundSource.isPlaying)
        {
            tickSoundSource.Stop();
        }

        // Stop the game
        Time.timeScale = 0f;
    }

    void UpdateCountdownText()
    {
        // Update the TMP text with the current time remaining
        countdownText.text =  Mathf.RoundToInt(timeRemaining).ToString();
    }

    public void InitializeTimer()
    {
        // Initialize timer values
        timeRemaining = 20f;
        isCounting = false;
        isGameRunning = true;

        // Deactivate the timer out panel at the start
        if (timerOutPanel != null)
        {
            timerOutPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Timer Out Panel GameObject is not assigned!");
        }

        // Start the countdown
        StartCountdown();
        
        // Reset the time scale
        Time.timeScale = 1f;
    }
}