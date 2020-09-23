using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    //My variables for player controller
    [SerializeField] private float movementSpeed = 2f;
    private float currentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.1f;
    private float rotationSpeed = 0.1f;
    private float gravity = 3f;

    //Camera varuable
    private Transform mainCameraTransform;

    private CharacterController controller;
    private Animator animator;
    public float InputX;
    public float InputY;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        InputY = Input.GetAxis("Vertical");
        animator.SetFloat("InputY", InputY);

        InputX = Input.GetAxis("Horizontal");
        animator.SetFloat("InputX", InputX);
        Move();

    }
    //Telling the character controller which buttons were pressing 
    private void Move()
    {
        //Vector 2 is a variable that hold two floats x and y, GetAxisRaw doesn't including anykind of smoothing
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();


        Vector3 desireMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        //Checking if the player is standing on some kind of surface if not they fall 
        if(!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }

        //Slerp is basically spherically interpolates between a and b by t, parameter t is kind of speed. Overall this is really rotating the player.
        if(desireMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desireMoveDirection), rotationSpeed);
        }

        //Calculate the speed the player wants to move, Mathf is moving from a to b with some kind of speed, similar to slerp,ref keyword indicates a value that is passed by reference
        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);


        controller.Move(desireMoveDirection * currentSpeed * Time.deltaTime);
        //making sure gravity works well with the frame rates
        controller.Move(gravityVector * Time.deltaTime);


        animator.SetFloat("MovementSpeed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
    }

}
