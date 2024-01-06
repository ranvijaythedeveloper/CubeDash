using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float rotationSpeed = 60.0f; 

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
