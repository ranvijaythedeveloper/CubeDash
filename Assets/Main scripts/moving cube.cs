using UnityEngine;

public class movingcube : MonoBehaviour
{
    [SerializeField] bool B_ShouldMoveLeft;
    private bool B_MovingLeft;
    [SerializeField] bool B_isLeftInitialized;
    private string S_hasLevelStarted;
    Rigidbody RB_rb;
    void Awake()
    {
        RB_rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        S_hasLevelStarted = PlayerPrefs.GetString("has level started");
        if (S_hasLevelStarted == "true")
        {
            if (B_ShouldMoveLeft)
            {
                if (!B_isLeftInitialized)
                {
                    B_MovingLeft = true;
                    B_isLeftInitialized = true;
                }
            }
            if (B_MovingLeft)
            {
                RB_rb.velocity = new Vector3(-5f, RB_rb.velocity.y, RB_rb.velocity.z);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                RB_rb.velocity = new Vector3(5f, RB_rb.velocity.y, RB_rb.velocity.z);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

    }
    public void ColliderOnCollide(string side)
    {
        if (side == "left")
        {
            B_MovingLeft = false;
        }
        if (side == "right")
        {
            B_MovingLeft = true;
        }
    }


}
