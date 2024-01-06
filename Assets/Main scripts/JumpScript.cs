using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScript : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody rb;
    public long jumpForce = 500;
    private bool IsPlayerGrounded = false;
    private Button button;
    public long jumpForce2;
    private bool isVelocityReduced = false;
    private bool startTimer = false;
    private Player playerclass;
    private animationHandler animHandler;
    private Vector3 distance;
    private float timer = 0f;
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        if (!IsPlayerGrounded)
        {
            // Height of Jump = 6.75 
            // Time to Jump = 1.533398
            // Distance: 34.2m
        }
    }
    void Awake()
    {
        rb = Player.GetComponent<Rigidbody>();
        playerclass = Player.GetComponent<Player>();
        animHandler = Player.GetComponent<animationHandler>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    void Start()
    {
        distance = new Vector3(0,0,0);
    }
    
    public void PlayerOnGround()
    {
        IsPlayerGrounded = true;
        // playerclass.ResetVelocity();
        isVelocityReduced = false;
        startTimer = false;
        distance = new Vector3(0,0, Player.transform.position.z - distance.z);
    }
    
    public void Jump(long jumpForce)
    {
        if (!isVelocityReduced)
        {
        // playerclass.ReduceVelocity();
        isVelocityReduced = true;
        }
        // Debug.Log("Jumping");
        rb.AddForce(0, jumpForce, -50000000);
        startTimer = true;
        distance = Player.transform.position;
        // animHandler.PlayAnimation("Jump");
        
    }

    public void ForceDown(long JumpForce2)
    {
        rb.AddForce(0, -JumpForce2, -50000000);
    }

    void OnButtonClick() 
    {
        if (IsPlayerGrounded)
        {
            // Debug.Log("Calling Jump");
            Jump(jumpForce);
            IsPlayerGrounded = false;
            StartCoroutine("TriggerForceDown");
        }
    }
    IEnumerator TriggerForceDown()
    {
        yield return new WaitForSeconds(0.5f);
        ForceDown(jumpForce2 * 5);
        rb.AddForce(0,0,-5000000);
        yield return new WaitForSeconds(0.1f);
        ForceDown(jumpForce2 * 15);
    }
}
