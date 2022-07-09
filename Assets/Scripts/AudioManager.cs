using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    
    private Target raycaster;
    [HideInInspector]
    public bool canPlayAudio;

    private void Start()
    {
        raycaster = Camera.main.transform.GetComponent<Target>();
    }

    void Update()
    {
        if (raycaster.isButtonDown && canPlayAudio)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (audioSource != null)
            audioSource.Stop();
    }
    
    public void PlayAudioSourceFrom(Transform a)
    {
        audioSource = a.GetComponent<AudioSource>();
        canPlayAudio = true;
    }

    public void Stop()
    {
        canPlayAudio = false;
    }
    
}