using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player_x;
    private PortalTeleport portalTeleport;
    private PortalCamera portalCamera;
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;
    private void Awake()
    {

        player_x = GameObject.FindGameObjectWithTag("Player");

        portalTeleport = portalCollider.GetComponent<PortalTeleport>();
        portalTeleport.receiver = otherPortal.portalCollider;
        portalTeleport.player = player_x.transform;

        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalCamera.playerCamera = player_x.GetComponentInChildren<Camera>().transform;
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = transform;

       

        renderSurface.GetComponent<Renderer>().material = Instantiate(material);

        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = 
            new RenderTexture(Screen.width, Screen.height, 24);

        

    }
    private void Start()
    {
        renderSurface.GetComponent<Renderer>().material.mainTexture =
             otherPortal.GetComponent<Portal>().myCamera.targetTexture;
    }

    


   
}

