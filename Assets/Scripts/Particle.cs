using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour

{
    public Transform IceParticle;
    // Start is called before the first frame update
    void Start()
    {
       IceParticle.GetComponent<ParticleSystem>().enableEmission = false;
    }
    void OnTriggerEnter()
    {
        Debug.Log("We triggered something!");
       IceParticle.GetComponent<ParticleSystem>().enableEmission = true;
        //StartCoroutine(stopIceParticle());


    }


}
