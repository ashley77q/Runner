using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part : MonoBehaviour
{
    public Transform IceParticle;
    // Start is called before the first frame update
    void Start()
    {
        IceParticle.GetComponent<ParticleSystem>().enableEmission = false;
    }
    void OnTriggerEnter2D()
    {

        IceParticle.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stopIceParticle());


    }

}
