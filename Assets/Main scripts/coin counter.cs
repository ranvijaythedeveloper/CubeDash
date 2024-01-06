using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coincounter : MonoBehaviour
{
    private TMP_Text coinCounterTMP;
    int coins;
    
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinCounterTMP = GetComponent<TMP_Text>();
        coinCounterTMP.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinCounterTMP.text = coins.ToString();
    }
}
