using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomAudio : MonoBehaviour
{
    AudioSource audioSource;
    public void PlayItemSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
