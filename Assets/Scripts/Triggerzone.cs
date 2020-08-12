using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerzone : MonoBehaviour
//Destroys any object that makes their way past the player
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    internal static void SetActive(bool v)
    {
        throw new NotImplementedException();
    }
}