using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingobstaclescript : MonoBehaviour
{
    // vars
    [SerializeField] float rotationSpeed = 60f;
    
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * ( rotationSpeed / 50 ) * Time.deltaTime);
    }
}
