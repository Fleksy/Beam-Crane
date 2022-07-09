using UnityEngine;

public class Target : MonoBehaviour
{
    public Texture centreCross;
    public int crossSize = 30;

    [HideInInspector] public bool isButtonDown;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isButtonDown = false;
    }

    void OnGUI()
    {
        GUI.DrawTexture(
            new Rect(Screen.width / 2 - crossSize / 2, Screen.height / 2 - crossSize / 2, crossSize, crossSize),
            centreCross);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.CompareTag("MoveController"))
                {
                    isButtonDown = true;
                    obj.GetComponent<MovingObjectController>().ActivateControlElement();
                }
                else
                    isButtonDown = false;
            }
        }
        else
            isButtonDown = false;
    }
}