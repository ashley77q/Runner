/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerthreeDMovement : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public float inputHoldDelay = 0.5f;

    private WaitForSeconds inputHoldWait;
    private Vector3 destinationPosition;

    private const float stopDistanceProportion = 0.1f;

    private void Start()
    {
        agent.updateRotation = false;

        inputHoldWait = new WaitForSeconds(inputHoldDelay);

        destinationPosition = transform.position;
    }

    private void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;




    }


    private void Update()
    {

        if(agent.pathPending)
        {
            return;


        }
        float speed = agent.desiredVelocity.magnitude;
        if(agent.remainingDistance <=agent.stoppingDistance * stopDistanceProportion)
        {

            Stopping(out speed);

        }
        else if(agent.remainingDistance <= agent.stoppingDistance)
        {

            Slowing(out speed, agent.remainingDistance);

        }
        else if(speed > ??)

    }


    private void Stopping (out float speed)
    {



    }
    private void Slowing (out float speed, float distanceToDestination)
    {




    }
    private void Moving()
    {





    }


}
*/