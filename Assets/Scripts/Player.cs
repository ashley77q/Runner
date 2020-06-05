using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    [Header("References")]

    public Gamemanager manager;
    public Material normalMat;
    public Material Hologram;
        

    [Header("Gameplay")]

    public float bounds = 3f;
    public float strafeSpeed = 4f;
    public float phaseCooldown = 2f;

    Renderer mesh;
    Collider collision;
    bool canPhase = true;

     void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        collision = GetComponent<Collider>();
    }

     void Update()
     // Starts by moving the player based off input
     // Clamp keeps the player in the gauntlet
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;
        Vector3 position = transform.position;
        position.x += xMove;
        position.x = Mathf.Clamp(position.x, -bounds, bounds);
        transform.position = position;

        //having some trouble with my custon shader phase function at this point

        if (Input.GetButtonDown("Jump") && canPhase)
        {


            canPhase = false;
            mesh.material = Hologram;
            collision.enabled = false;

            Invoke("PhaseIn", phaseCooldown);
        }
    }

    void PhaseIn()
    {
        canPhase = true;
        mesh.material = normalMat;
        collision.enabled = true;

    }

}