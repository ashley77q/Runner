using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public Gamemanager manager;
    public float moveSpeed = 20f;
    public float timeAmount = 1.5f;

    void Update()
    //when the object collides with something, it checks to see if it collided with the player
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
            manager.AdjustTime(timeAmount);
                Destroy(gameObject);
            }

        }

    }
