using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreedControl : MonoBehaviour
{
    public Animator animator;
    public float InputX;
    public float InputY;



    //Use this for initialization
    private void Start()
    {
        //Get the animator
        animator = this.gameObject.GetComponent<Animator>();
    }



  

    //Update is called once per frame
    private void Update()
    {
        InputY = Input.GetAxis("Vertical");
        animator.SetFloat("InputY", InputY);

        InputX = Input.GetAxis("Horizontal");
        animator.SetFloat("InputX", InputX);

        
    }
}