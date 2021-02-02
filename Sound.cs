using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}