using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class consumablepowerups : MonoBehaviour
{
    private string shieldCheck;
    private Button shieldButton;

    void Start()
    {
        // shieldCheck = PlayerPrefs.SetString("false");
        shieldButton = GetComponent<Button>();
        shieldButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {

    }
}
