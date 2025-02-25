using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
   



    public void OnTriggerEnter(Collider gracz)
    {
        if (gracz.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }
    public void OnTriggerExit(Collider gracz)
    {
        if (gracz.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    void Teleportation()
    {
        if (playerIsOverlapping)
        {
            Vector3 Odleglosc_Gracza_do_Portalu = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, Odleglosc_Gracza_do_Portalu);
            if (dotProduct < 0) 
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f)
                    * Odleglosc_Gracza_do_Portalu;

                player.position = receiver.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    //Exit

    private void FixedUpdate()
    {
        Teleportation();
    }



}


