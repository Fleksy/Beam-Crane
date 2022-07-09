using System;
using UnityEngine;

public class CraneMoveScript : ControlledObject
{
    [Header("Limit Points and Speed")] public int forwardSpeed = 5;
    public GameObject limitPointForward;

    public int backSpeed = 5;
    public GameObject limitPointBack;

    public int leftSpeed = 5;
    public GameObject limitPointLeft;

    public int rightSpeed = 5;
    public GameObject limitPointRight;

    public int upSpeed = 5;
    public GameObject limitPointUp;

    public int downSpeed = 5;
    public GameObject limitPointDown;

    [Header("Part of Crane")] public Transform Crane;
    public Transform Hook;
    public Transform Tube;
    public Wire tubeWire;
    public Wire controllerWire;

    [Header("Other")] public AudioManager audioManager;


    private void Awake()
    {
        MovingObjectController.OnControlElementActivated.AddListener(GetCommand);
    }

    public override void GetCommand(MovingObjectController.CommandType direction)
    {
        switch (direction)
        {
            case MovingObjectController.CommandType.Forward:
                MoveForward();
                break;

            case MovingObjectController.CommandType.Back:
                MoveBack();
                break;

            case MovingObjectController.CommandType.Left:
                MoveLeft();
                break;

            case MovingObjectController.CommandType.Right:
                MoveRight();
                break;

            case MovingObjectController.CommandType.Up:
                MoveUp();
                break;

            case MovingObjectController.CommandType.Down:
                MoveDown();
                break;

            default:
                throw new ArgumentException($"Unknown behaviour: {direction}");
        }
    }


    void MoveForward()
    {
        if (transform.position.z < limitPointForward.transform.position.z)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.fixedDeltaTime);
            controllerWire.Stretch();
            audioManager.PlayAudioSourceFrom(transform);
        }
    }

    void MoveBack()
    {
        if (transform.position.z > limitPointBack.transform.position.z)
        {
            transform.Translate(Vector3.back * backSpeed * Time.fixedDeltaTime);
            controllerWire.Stretch();
            audioManager.PlayAudioSourceFrom(transform);
        }
    }

    void MoveLeft()
    {
        if (Crane.position.x > limitPointLeft.transform.position.x)
        {
            Crane.Translate(Vector3.left * leftSpeed * Time.fixedDeltaTime);
            controllerWire.Stretch();
            audioManager.PlayAudioSourceFrom(Crane);
        }
    }

    void MoveRight()
    {
        if (Crane.position.x < limitPointRight.transform.position.x)
        {
            Crane.Translate(Vector3.right * rightSpeed * Time.fixedDeltaTime);
            controllerWire.Stretch();
            audioManager.PlayAudioSourceFrom(Crane);
        }
    }

    void MoveUp()
    {
        if (Hook.position.y < limitPointUp.transform.position.y)
        {
            Hook.Translate(Vector3.up * upSpeed * Time.fixedDeltaTime);
            Tube.Rotate(Vector3.left * leftSpeed);
            tubeWire.Stretch();
            audioManager.PlayAudioSourceFrom(Tube);
        }
    }

    void MoveDown()
    {
        if (Hook.position.y > limitPointDown.transform.position.y)
        {
            Hook.Translate(Vector3.down * downSpeed * Time.fixedDeltaTime);
            Tube.Rotate(Vector3.right * rightSpeed);
            tubeWire.Stretch();
            audioManager.PlayAudioSourceFrom(Tube);
        }
    }
}