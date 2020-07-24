using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemControllerWindow : MonoBehaviour

{

    public ParticleSystem RocketAirTwo;


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