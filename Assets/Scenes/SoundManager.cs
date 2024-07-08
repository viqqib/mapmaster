using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource btnSource;
    public AudioClip bgm;
    public AudioClip buttonClickSound;
    private bool isMuted = false;

    private void Start()
    {
        musicSource.clip = bgm;
        if (!isMuted)
        {
            musicSource.Play();
        }
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            musicSource.PlayOneShot(buttonClickSound);
        }
    }

    public void StopBGM()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
