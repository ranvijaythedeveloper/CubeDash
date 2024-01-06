using UnityEngine;
using UnityEngine.SceneManagement;
using TheDeveloperTrain.utils;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private AudioSource PlayerAudioSource;
    private Renderer PlayerRenderer;
    public Material Purple;
    public Material Green;
    private float storedforwardspeed;
    private bool isgameactive = false;
    public Material CyanTypeBlue;
    public Material Pink;
    public Material Yellow;
    public Material Cyan;
    public Material PurpleMetallic;
    public Material GreenMetallic;
    public Material CyanTypeBlueMetallic;
    public Material PinkMetallic;
    public Material YellowMettalic;
    public Material CyanMetallic;
    private int buttunvalue;
    private bool istoggleon = false;
    private Rigidbody rb;
    private bool IncrementedLvl11 = false;
    public int lvl10buildindex;
    private float forwardspeed;
    private float sidespeed;
    private bool isfinishvisible;
    private Scene currentscene;
    private int buildIndex;
    private bool hascollidedwithobstacle = false;
    public AudioClip obstaclesound;
    public AudioClip finishsound;
    public Image nextlevel;
    public TMP_Text nextleveltmp;
    public Image restartlevel;
    public TMP_Text restartleveltmp;
    public Image mainmenu;
    public TMP_Text mainmenutmp;
    public  int[] parkourLvlBuildIndexes;
    public Button jumpBtn;
    private bool isShielded;
    public GameObject shield;
    
    
    public enum Platform
    {
        Pc,
        Mobile
    }
    public Platform platform;
    private void Awake()
    {
        currentscene = SceneManager.GetActiveScene();
        buildIndex = currentscene.buildIndex;
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
        for (int i = 0; i < parkourLvlBuildIndexes.Length; i++)
        {
            if (buildIndex == parkourLvlBuildIndexes[i])
            {
                Time.timeScale = 1.5f;
                // jumpBtn.interactable = true;
            }
        }
        storedforwardspeed = forwardspeed;
        PlayerRenderer = GetComponent<Renderer>();
        PlayerPrefs.SetString("sound manager bool", "false");
        PlayerAudioSource = GetComponent<AudioSource>();
        PlayerAudioSource.Stop();
        // if nest
        if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 1)
        {
            PlayerRenderer.material = Purple;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 2)
        {
            PlayerRenderer.material = Green;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 3) 
        {
            PlayerRenderer.material = CyanTypeBlue;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 4)
        {
            PlayerRenderer.material = Pink;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 5)
        {
            PlayerRenderer.material = Yellow;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 6)
        {
            PlayerRenderer.material = Cyan;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 7)
        {
            PlayerRenderer.material = PurpleMetallic;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 8)
        {
            PlayerRenderer.material = GreenMetallic;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 9)
        {
            PlayerRenderer.material = CyanTypeBlueMetallic;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 10)
        {
            PlayerRenderer.material = PinkMetallic;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 11)
        {
            PlayerRenderer.material = YellowMettalic;
        }
        else if (PlayerPrefs.GetInt("PlayerMaterialIndex") == 12)
        {
            PlayerRenderer.material = CyanMetallic;
        }
    }
    public void buttononclick(string id)
    {
        if (id == "left")
        {
            buttunvalue = -1;
        }
        else if (id == "right")
        {
            buttunvalue = 1;
        }
        else if (id == "next lvl")
        {
            if (isfinishvisible)
            {
                SceneManager.LoadScene(buildIndex + 1);
            }
        }
        else if (id == "restart lvl")
        {
            if (isfinishvisible)
            {
                Resetlevel();
            }
        }
        else if (id == "main menu")
        {
            if (isfinishvisible)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void buttononrelease()
    {
        buttunvalue = 0;
    }
    private void FixedUpdate()
    {
        forwardspeed = 20f;
        sidespeed = 10f;
        IncrementedLvl11 = true;
        
        if (!hascollidedwithobstacle && !isfinishvisible)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (PlayerPrefs.GetString("sound manager bool") == "false")
        {
            PlayerAudioSource.Stop();
        }
        if (PlayerPrefs.GetString("has level started") == "true")
        {
            rb.useGravity = true;
            istoggleon = true;
            isgameactive = true;
        }
        else
        {
            rb.useGravity = false;
            istoggleon = false;
        }
        if (istoggleon)
        {
            if (isgameactive)
            {
                if (buildIndex > lvl10buildindex)
                {
                    if (!IncrementedLvl11)
                    {
                        forwardspeed = 22.5f;
                        sidespeed = 11.25f;
                        IncrementedLvl11 = true;
                    }
                }
                if (platform == Platform.Pc)
                {
                    rb.velocity = new Vector3(Input.GetAxis("Horizontal") * sidespeed, rb.velocity.y, forwardspeed);
                }
                else if (platform == Platform.Mobile)
                {
                    rb.velocity = new Vector3(buttunvalue * sidespeed, rb.velocity.y, forwardspeed);
                }
                if (transform.position.y < -1)
                {
                    Resetlevel();
                }
            }
        }
    }

    private void Resetlevel()
    {
        isfinishvisible = false;
        hascollidedwithobstacle = false;
        PlayerPrefs.SetString("sound manager bool", "false");
        SceneManager.LoadScene(buildIndex);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (isShielded)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                if (!hascollidedwithobstacle)
                {
                    PlayerPrefs.SetString("sound manager bool", "true");
                    PlayerAudioSource.PlayOneShot(obstaclesound);
                    Invoke("Resetlevel", 1f);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            PlayerPrefs.SetString("sound manager bool", "true");
            PlayerAudioSource.PlayOneShot(finishsound);
            rb.isKinematic = true;
            isfinishvisible = true;
            nextlevel.color = Color.white;
            nextleveltmp.color = Color.black;
            restartlevel.color = Color.white;
            restartleveltmp.color = Color.black;
            mainmenu.color = Color.white;
            mainmenutmp.color = Color.black;
        }
    }

    public void ShieldCollided(GameObject caller)
    {
        shield.SetActive(true);
        Invoke("resetIsSheilded", 5f);
    }
    

    private void turnofftoggle()
    {
        istoggleon = false;
    }
    private void resetIsSheilded()
    {
        shield.SetActive(false);
    }
    public void ReduceVelocity()
    {
        // storedforwardspeed = forwardspeed;
        // forwardspeed = forwardspeed;
        // Debug.Log(forwardspeed);
    }
    public void ResetVelocity()
    {
        forwardspeed = storedforwardspeed;
    }
    
}