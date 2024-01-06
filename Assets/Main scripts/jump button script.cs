using UnityEngine;
using UnityEngine.UI;

public class JumpClass : MonoBehaviour
{
    public float jumpForce = 5.0f;
    private Rigidbody rb;
    public GameObject player;
    bool isGrounded = false;
    public float raycastDistance = 0.1f;
    public LayerMask groundLayer;
    public Button jumpButton;

    void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        jumpButton.onClick.AddListener(Jump);
    }

    void FixedUpdate()
    {
        if (Physics.CheckCapsule(GetComponent<Collider>().bounds.center, 
            new Vector3(GetComponent<Collider>().bounds.center.x, 
            GetComponent<Collider>().bounds.min.y - 0.1f, 
            GetComponent<Collider>().bounds.center.z), 
            GetComponent<Collider>().bounds.extents.x * 0.9f, groundLayer.value))
        {
            Debug.Log("Player is on the ground.");
            isGrounded = true;
        }
        else
        {
            Debug.Log("Player is not on the ground.");
            isGrounded = false;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("isGrounded is " + isGrounded);
        }
        else
        {
            Debug.Log("isGrounded is " + isGrounded);
        }
    }
}
