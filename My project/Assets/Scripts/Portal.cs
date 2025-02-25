using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player_x;
    private PortalTeleport portalTeleport;

    private void Awake()
    {
        player_x = GameObject.FindGameObjectWithTag("Player");

        portalTeleport = portalCollider.GetComponent<PortalTeleport>();
        portalTeleport.receiver = otherPortal.portalCollider;
        portalTeleport.player = player_x.transform;

        renderSurface.GetComponent<Renderer>().material = Instantiate(material);

        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = 
            new RenderTexture(Screen.width, Screen.height, 24);

    }

    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    


}
