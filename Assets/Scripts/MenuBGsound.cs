using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGsound : MonoBehaviour
{
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
