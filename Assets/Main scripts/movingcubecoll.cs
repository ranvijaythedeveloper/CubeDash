using UnityEngine;

public class Movingcubecoll : MonoBehaviour
{
    [SerializeField] GameObject Movingcube;
    enum Colliders{
        leftcoll,
        rightcoll
    }
    [SerializeField] Colliders thiscollider;
    movingcube cubeclass;

    void Awake()
    {
        cubeclass = Movingcube.GetComponent<movingcube>();
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(Parse(thiscollider));
        cubeclass.ColliderOnCollide(Parse(thiscollider));
    }
    private string Parse(Colliders collider)
    {
        if (collider == Colliders.leftcoll)
        {
            return "left";
        }
        else 
        {
            return "right";
        }
    }
}
