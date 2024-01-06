using UnityEngine;

public class Trapactivator : MonoBehaviour
{
    [SerializeField] readonly GameObject Manager;
    Trapmanager managerclass;

    void Awake()
    {
        managerclass = Manager.GetComponent<Trapmanager>();
    }

    void OnTriggerEnter(Collider other)
    {
        managerclass.Activatorcollided();
    }
}
