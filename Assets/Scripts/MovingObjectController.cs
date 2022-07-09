using UnityEngine;
using UnityEngine.Events;

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
    public CommandType command; // команда, назначенная этому конкретному элементу управления
    
    public static readonly UnityEvent<CommandType> OnControlElementActivated = new UnityEvent<CommandType>();
    
    public void ActivateControlElement()
    {
        OnControlElementActivated.Invoke(command);
    }
}