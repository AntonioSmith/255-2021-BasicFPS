using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorArt;

    private float doorAngle = 0;
    public float animLength = 0.5f;
    private float animTimer = 0;

    private bool animIsPlaying = false;
    private bool isClosed = true;
    void Start()
    {
        
    }
    void Update()
    {
        // anim is playing
        if (animIsPlaying)
        {
            if (isClosed)
                animTimer += Time.deltaTime; // play forwards
            else
                animTimer -= Time.deltaTime; // play backwards

            float percent = animTimer / animLength;

            if (percent < 0 && isClosed)
                {
                    percent = 0;
                    animIsPlaying = false;
                }

            if (percent > 1 && !isClosed)
                {
                    percent = 1;
                    animIsPlaying = false;
                }

            //doorAngle = percent * 90;                                                      // original code used to set door angle
            //doorArt.rotation = Quaternion.Euler(0, doorAngle, 0); // set angle of doorArt

            doorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0); // set angle of doorArt
        }
    }

    public void PlayerInteract(Vector3 position)
    {
        if (animIsPlaying) return; // do nothing

        if (!Inventory.main.hasKey) return; // do nothing

        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized;

        bool playerOnOntherSide = (Vector3.Dot(disToPlayer, transform.forward) > 0f);

        isClosed = !isClosed; // toggles isClosed state

        doorAngle = 90;
        if (playerOnOntherSide) doorAngle = -90;        

        //if (isClosed) isClosed = false; // another way to toggle isClosed state
        //else isClosed = true;

        animIsPlaying = true;

        // sets playhead to end or beginning
        if (isClosed) animTimer = animLength;
        else animTimer = 0;
    }
}
