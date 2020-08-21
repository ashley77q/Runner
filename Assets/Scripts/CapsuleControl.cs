using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour

{
    //get access function
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float rotationRate = 360;
    public float moveSpeed = 2;

    #region Monobehaviour API
    //every frame update our position and roatation
    private void Update()
    {
        //going and grabbing a value between -1 and 1
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);

    }
    private void ApplyInput(float moveInput,float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);


    }
    
    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
       
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);


    }
    #endregion

}

