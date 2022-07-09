using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Target raycaster;
    
    void Update()
    {
        if (raycaster.isButtonDown)
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
    }
}