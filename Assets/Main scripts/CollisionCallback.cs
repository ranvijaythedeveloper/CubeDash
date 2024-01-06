using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCallback : MonoBehaviour
{
    public GameObject JumpButton;
    private JumpScript jumpScript;
    void Awake()
    {
        jumpScript = JumpButton.GetComponent<JumpScript>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        jumpScript.PlayerOnGround();
    }
}
