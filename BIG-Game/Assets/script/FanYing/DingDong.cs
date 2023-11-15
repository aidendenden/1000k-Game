using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingDong : MonoBehaviour
{
    public AudioClip A1;
    public AudioClip A2;


    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found!");
        }
        else
        {
           // PlayAudio();
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.LogWarning("AudioSource component not found!");
        }
    }

    public void PlayAudioTwo()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(A1);
        }
        else
        {
            Debug.LogWarning("AudioSource component not found!");
        }
    }

    public void PlayAudioThree()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(A2);
        }
        else
        {
            Debug.LogWarning("AudioSource component not found!");
        }
    }
}
