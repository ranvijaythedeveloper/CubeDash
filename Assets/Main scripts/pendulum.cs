using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float leftMaxAngle = -60f;
    [SerializeField] private float rightMaxAngle = 60f;
    [SerializeField] private float speed = 1f;
    private bool movingLeft = false;

    void Update()
    {
        float currentAngle = transform.rotation.eulerAngles.z;

        if (movingLeft)
        {
            if (Mathf.DeltaAngle(currentAngle, leftMaxAngle) < 0f)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 100f * speed);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (Mathf.DeltaAngle(currentAngle, rightMaxAngle) > 0f)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 100f * speed);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}
