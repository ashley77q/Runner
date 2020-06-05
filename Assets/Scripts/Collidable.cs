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

        Debug.Log($"OnTriggerEnter is running. {name} hit {other.name}");


        var player = other.GetComponent<Player>();
        if (player == null)
        {
            // We didn't hit the player.
        }
        else
        {
            manager.AdjustTime(timeAmount);
            Destroy(gameObject);
        }
    }
}







