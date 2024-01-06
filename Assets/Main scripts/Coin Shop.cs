using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CoinShop : MonoBehaviour, IPointerClickHandler
{
    //------------------------------- Start of vars -------------------------------------
    public string SkinId;
    public int PlayerMaterialIndex;
    public int price;
    public GameObject tmp;
    public GameObject coin;
    private Image coinImage;
    private TMPro.TextMeshPro tmpcomp;
    private RectTransform tmprt;
    private const string ACTIVESTRINGID = "ActiveStringId";
    string ActiveSkinId;
    //------------------------------ End of vars ----------------------------------------

    //------------------------- Start of SetSkins function ------------------------------
    // WILL CHECK THE SKIN ID AND SET THE ACTIVE SKINS BECAUSE IT IS MADE TO DO THIS ONLY;;
    public void SetSkins()
    {
        if (SkinId == "Purple")
        {
            PlayerPrefs.SetString(SkinId, "Purple");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 1);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "Green")
        {
            PlayerPrefs.SetString(SkinId, "Green");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 2);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "CyanTypeBlue")
        {
            PlayerPrefs.SetString(SkinId, "CyanTypeBlue");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 3);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "Pink")
        {
            PlayerPrefs.SetString(SkinId, "Pink");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 4);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "Yellow")
        {
            PlayerPrefs.SetString(SkinId, "Yellow");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 5);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "Cyan")
        {
            PlayerPrefs.SetString(SkinId, "Cyan");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 6);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "PurpleM")
        {
            PlayerPrefs.SetString(SkinId, "PurpleM");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 7);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "GreenM")
        {
            PlayerPrefs.SetString(SkinId, "GreenM");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 8);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "CyanTypeBlueM")
        {
            PlayerPrefs.SetString(SkinId, "CyanTypeBlueM");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 9);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "PinkM")
        {
            PlayerPrefs.SetString(SkinId, "PinkM");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 10);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "YellowM")
        {
            PlayerPrefs.SetString(SkinId, "YellowM");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 11);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
        else if (SkinId == "CyanM")
        {
            PlayerPrefs.SetString(SkinId, "CyanM");
            PlayerPrefs.SetInt("PlayerMaterialIndex", 12);
            PlayerPrefs.SetString(ActiveSkinId, SkinId);
        }
    }
    //------------------------- End of SetSkins function ------------------------------

    //------------------------- Start of OnPointerClick functions ------------------------------
    // THIS FUNCTION WILL CHECK THE CLICK AND BUY THE SKIN BECAUSE.......... YOU KNOW IT;;;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (PlayerPrefs.GetString(SkinId) == "false")
        {
            PlayerPrefs.SetString("preview Id", SkinId);
            PlayerPrefs.SetInt("preview price", price);
            SceneManager.LoadScene(1);
        }
        else
        {
            SetSkins();
        }
    }
    //------------------------- End of OnPointerClick functions ------------------------------

    //----------------------------- Start of Start function ------------------------------
    // THIS FUNCTION WILL DO SOMETHING....... YES "SOMETHING" BECAUSE..........;;;;

    private void Start()
    {
        ActiveSkinId = PlayerPrefs.GetString(ACTIVESTRINGID);
        coinImage = coin.GetComponent<Image>();
        tmpcomp = tmp.GetComponent<TMPro.TextMeshPro>();
        tmprt = tmp.GetComponent<RectTransform>();
        if (PlayerPrefs.GetString(SkinId) == "false")
        {
            price = int.Parse(tmpcomp.GetParsedText());
        }
        else
        {
            tmpcomp.SetText("Purchased");
            coinImage.tintColor = Color.clear;
            tmprt.anchoredPosition = new Vector2(tmprt.anchoredPosition.x - 5, tmprt.anchoredPosition.y);
            if (ActiveSkinId == SkinId)
            {
                tmpcomp.SetText("Purchased");
                tmprt.anchoredPosition = new Vector2(tmprt.anchoredPosition.x - 5, tmprt.anchoredPosition.y);
            }
        }
    }
    //----------------------------- End of Start function ------------------------------
}
