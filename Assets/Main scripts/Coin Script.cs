using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public enum CoinPoints
    {
        OnePointCoin = 1,
        FivePointCoin = 5
    }
    public CoinPoints cointype;
    private int coinvalue;
    private AudioSource playeraudiosource;
    public AudioClip audioclip;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playeraudiosource = player.GetComponent<AudioSource>();
        if (cointype == CoinPoints.OnePointCoin)
        {
            coinvalue = 1;
        }
        else if (cointype == CoinPoints.FivePointCoin)
        {
            coinvalue = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coinvalue);
            PlayerPrefs.SetString("sound manager bool", "true");
            playeraudiosource.PlayOneShot(audioclip);
            Destroy(this.gameObject);
        }
    }
}
