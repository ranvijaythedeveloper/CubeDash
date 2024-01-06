using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAnimation(string newAnimation)
    {
        anim.Play("animations"); 
    }
}
