using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class pausegamegraphscript : MonoBehaviour
{
    Image mainMenuBtnImage;
    Image resumeBtnImage;
    Image pausebtnImage;
    Button pauseBtn;
    Button resumeBtn;
    Button mainmenuBtn;
    public GameObject pausebtn;
    public GameObject mainmenubtn;
    public GameObject resumebtn;
    public TMP_Text mainMenuBtnTMP;
    public TMP_Text resumeBtnTMP;
    public TMP_Text PauseTMP;
    private bool isVisible = false;
    private bool isParkour = false;
    private float activeRunningTimeScale = 1f;
    public Player player;


    void Start()
    {
        for (int i = 0;i < player.parkourLvlBuildIndexes.Length; i++)
        {
            if (player.parkourLvlBuildIndexes[i] == SceneManager.GetActiveScene().buildIndex)
            {
                isParkour = true;
            }
        }
        if (isParkour)
        {
            activeRunningTimeScale = 1.5f;
            SetTimeScale(activeRunningTimeScale);
        }
        else
        {
            activeRunningTimeScale = 1f;
            SetTimeScale(activeRunningTimeScale);
        }

        pauseBtn = pausebtn.GetComponent<Button>();
        resumeBtn = resumebtn.GetComponent<Button>();
        mainmenuBtn = mainmenubtn.GetComponent<Button>();
        mainMenuBtnImage = mainmenubtn.GetComponent<Image>();
        Debug.Log(mainMenuBtnImage);
        resumeBtnImage = resumebtn.GetComponent<Image>();
        Debug.Log(resumeBtnImage);
        pausebtnImage = pausebtn.GetComponent<Image>();
        Debug.Log(pausebtnImage);
        pauseBtn.onClick.AddListener(onclickforpause);
        resumeBtn.onClick.AddListener(onclickforresume);
        mainmenuBtn.onClick.AddListener(mainmenubtnOnClick);
        Debug.Log("info started");
        Debug.Log(player.parkourLvlBuildIndexes);
        Debug.Log(activeRunningTimeScale);

    }

    void Update()
    {
        
    }

    void onclickforpause()
    {
        mainMenuBtnImage.color = Color.white;
        mainMenuBtnTMP.color = Color.black;
        resumeBtnImage.color = Color.white;
        resumeBtnTMP.color = Color.black;
        PauseTMP.color = Color.black;
        pausebtnImage.color = Color.white;
        isVisible = true;
        SetTimeScale(0f);
    }

    void onclickforresume()
    {
        if ( isVisible )
        {
            pauseBtn.enabled = true;
            mainmenuBtn.enabled = false;
            mainMenuBtnTMP.enabled = false;
            resumeBtn.enabled = false;
            resumeBtnTMP.enabled = false;
            PauseTMP.enabled = true;

            isVisible = false;
            SetTimeScale(activeRunningTimeScale);
        }
    }
    void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    void mainmenubtnOnClick()
    {
        if ( isVisible )
        {
            SceneManager.LoadScene(0);
        }
    }
}
