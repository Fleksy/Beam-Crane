using UnityEngine;

// От этого класса должны наследоваться все обьекты, которые управляются реализованной мной системой управления
// ( на случай, если нужно создать не кран, а что-то в корне другое)
public abstract class ControlledObject : MonoBehaviour
{
    public abstract void GetCommand(MovingObjectController.CommandType direction);
}