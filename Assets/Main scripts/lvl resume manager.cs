using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlresumemanager : MonoBehaviour
{
    string isresume;
    int currentlvl;
    Scene currentscene;

    void Start()
    {
        isresume = PlayerPrefs.GetString("isresume");
        currentscene = SceneManager.GetActiveScene();
        currentlvl = currentscene.buildIndex;
        PlayerPrefs.SetInt("currentlvl", currentlvl);
        if (isresume == "true")
        {
            SceneManager.LoadScene(currentlvl);
        }
    }
}
