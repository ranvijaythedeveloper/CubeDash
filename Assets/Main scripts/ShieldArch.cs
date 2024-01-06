using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldArch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Finish"))
        {
            Destroy(other.gameObject);
        }
    }
}
