using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemControllerWindow : MonoBehaviour

{

    public ParticleSystem RocketAirTwo;


    //Use this for initialization
    private void Start()
    {

    }
    //Update is called once per frame
    private void Update()
    {

    }
    public void ToggleParticle()
    {

        if (RocketAirTwo.isPlaying)
        {

            RocketAirTwo.Stop();
        }
        else
        {
            RocketAirTwo.Play();


        }

    }


}