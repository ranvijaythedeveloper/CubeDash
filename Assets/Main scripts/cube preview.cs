using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class coinpreview : MonoBehaviour
{
    public float rotationSpeed = 60.0f;
    MeshRenderer meshRenderer;
    string ActiveSkin = PlayerPrefs.GetString("ActiveSkin");
    int PlayerMaterialIndex = PlayerPrefs.GetInt("PlayerMaterialIndex");
    string SkinId = PlayerPrefs.GetString("SkinId");
    string previewId = PlayerPrefs.GetString("preview Id");
    

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * ( rotationSpeed / 50 ) * Time.deltaTime);
    }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        if (previewId == "Purple")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 1);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "Green")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 2);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "CyanTypeBlue")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 3);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "Pink")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 4);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "Yellow")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 5);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "Cyan")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 6);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "PurpleM")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 7);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "GreenM")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 8);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "CyanTypeBlueM")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 9);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "PinkM")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 10);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "YellowM")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 11);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
        else if (previewId == "CyanM")
        {
            PlayerPrefs.SetInt("PlayerMaterialIndex", 12);
            PlayerPrefs.SetString(ActiveSkin, previewId);
        }
    }
}
