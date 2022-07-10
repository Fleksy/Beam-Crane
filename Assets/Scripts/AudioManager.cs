using System;
using UnityEngine;

[RequireComponent(typeof(CraneMoveScript))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public  Target raycaster;

    private CraneMoveScript craneMover;


    private void Start()
    {
        craneMover = transform.GetComponent<CraneMoveScript>();
        MovingObjectController.OnControlElementActivated.AddListener(PlayAudioSource);
    }

    void Update()
    {
        if (raycaster.isButtonDown && craneMover.canPlayAudio)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (audioSource != null)
            audioSource.Stop();
    }

     void PlayAudioSource(MovingObjectController.CommandType command)
    {
        if (command == MovingObjectController.CommandType.Back || command == MovingObjectController.CommandType.Forward)
        {
            audioSource = craneMover.transform.GetComponent<AudioSource>();
        }
        else if (command == MovingObjectController.CommandType.Left ||
                 command == MovingObjectController.CommandType.Right)
        {
            audioSource = craneMover.Crane.GetComponent<AudioSource>();
        }
        else if (command == MovingObjectController.CommandType.Up ||
                 command == MovingObjectController.CommandType.Down)
        {
            audioSource = craneMover.Tube.GetComponent<AudioSource>();
        }
        else
        {
            throw new ArgumentException($"Unknown behaviour: {command}");
        }
    }
}