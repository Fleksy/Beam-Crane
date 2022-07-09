using UnityEngine;

public class MovingObjectController : MonoBehaviour
{
    // Набор доступных для этого типа элементов управления команд
    public enum CommandType
    {
        Forward,
        Back,
        Left,
        Right,
        Up,
        Down
    }

    public ControlledObject
        controlledObject; // Обьект,которому должен передавать команду этот элемент управления

    public CommandType comand; // команда, назначенная этому конкретному элементу управления


    public void ActivatedButtonEffect()
    {
        controlledObject.GetCommand(comand);
    }
}