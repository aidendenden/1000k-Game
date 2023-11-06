using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingDong : MonoBehaviour
{
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
}
