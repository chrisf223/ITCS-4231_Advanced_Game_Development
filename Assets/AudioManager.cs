using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip backround;
    public AudioClip cameraSound;
    public AudioClip defeat;
    public AudioClip victory;
    public AudioClip incorrect;

    private void Start()
    { 
        musicSource.clip = backround;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
