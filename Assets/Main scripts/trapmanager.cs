using UnityEngine;

public class Trapmanager : MonoBehaviour
{
    public GameObject obstacle;
    Rigidbody rb;

    void Start()
    {
        rb.useGravity = false;
    }

    void Awake()
    {
        rb = obstacle.GetComponent<Rigidbody>();
    }

    public void Activatorcollided()
    {
        rb.useGravity = true;
    }
}
