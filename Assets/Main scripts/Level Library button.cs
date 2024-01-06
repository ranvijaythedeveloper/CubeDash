using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelLibrarybutton : MonoBehaviour, IPointerDownHandler
{
    public int levelbuildindex;
    private bool isunlocked;
    [SerializeField] GameObject lockicon;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("current level") < levelbuildindex)
        {
            isunlocked = true;
            lockicon.SetActive(false);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(isunlocked)
        {
            SceneManager.LoadScene(levelbuildindex);
        }
    }

}
