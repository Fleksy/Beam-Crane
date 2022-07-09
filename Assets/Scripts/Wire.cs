using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector3 firstPoint, secondPoint;
    public Transform FirstPoint;
    public Transform SecondPoint;

    // Метод растягивает провод от пульта управления и трос между точками их крепления
    public void Stretch()
    {
        firstPoint = FirstPoint.transform.position;
        secondPoint = SecondPoint.transform.position;
        SetPosition();
        SetScale();
        SetRotation();
    }

    void SetPosition()
    {
        Vector3 center = new Vector3((firstPoint.x + secondPoint.x) / 2, (firstPoint.y + secondPoint.y) / 2,
            (firstPoint.z + secondPoint.z) / 2);
        transform.position = center;
    }

    void SetScale()
    {
        float spaceBetween = Mathf.Sqrt
        (
            Mathf.Pow(firstPoint.x - secondPoint.x, 2) +
            Mathf.Pow(firstPoint.y - secondPoint.y, 2) +
            Mathf.Pow(firstPoint.z - secondPoint.z, 2)
        );
        transform.localScale = new Vector3(transform.localScale.x, spaceBetween / 2, transform.localScale.z);
    }

    void SetRotation()
    {
        transform.LookAt(FirstPoint);
        transform.Rotate(new Vector3(90, 0, 0));
    }
}