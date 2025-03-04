using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera; // Kamera gracza
    public Transform portal; // nasz w³asny portal
    public Transform otherPortal; // Portal do którego zmierzamy

    void Update()
    {
        PortalControllCamera();
    }

    private void Awake()
    {
        otherPortal = otherPortal.transform;
        portal = transform;
    }

    void PortalControllCamera()
    {
        // Odleg³oœæ
        Vector3 playerOffsetFromCameraPortal = playerCamera.position
            - otherPortal.position; // Odleg³oœæ gracza od portalu
        transform.position = portal.position + playerOffsetFromCameraPortal;

        // Obrót
        float DifferenceBetweenPortalRotations = Quaternion.Angle
            (portal.rotation, otherPortal.rotation);

        Quaternion portalRotationUp = Quaternion.
            AngleAxis(DifferenceBetweenPortalRotations, Vector3.up);

        Vector3 CameraDirection = portalRotationUp * playerCamera.forward;

        CameraDirection = new Vector3(CameraDirection.x * (-1),
            CameraDirection.y, CameraDirection.z * (-1));

        transform.rotation = Quaternion.LookRotation(CameraDirection, Vector3.up);

    }

}
