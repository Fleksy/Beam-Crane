using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 3f;


    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0, Space.World);
        transform.Rotate(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0, Space.Self);
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}