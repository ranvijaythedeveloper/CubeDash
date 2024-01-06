using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        Player player = other.gameObject.GetComponent<Player>();
        player.ShieldCollided(this.gameObject);
        }
        Debug.Log("Shield collided");
    }
}
