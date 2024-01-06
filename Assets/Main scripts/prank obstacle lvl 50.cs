using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prankobstaclelvl50 : MonoBehaviour
{
    MeshRenderer mr;
    public Color obstacleColor;

    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "special obstacle")
        {
            mr.material.color = obstacleColor;
        }
    }
}
