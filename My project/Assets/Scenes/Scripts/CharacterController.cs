using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerr : MonoBehaviour
{

    [SerializeField] private float speed = 10.5f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 12.0f;

    Vector3 velocity; // Prêdkoœæ
    CharacterController characterController; // kontroler postaci
    public bool isGrounded;
    public LayerMask groundCheckMask;
    public Transform groundPlaceCheck;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move*speed*Time.deltaTime);

        RaycastHit hit; //  Zmienna na informacje o uderzeniu
        if (Physics.Raycast(groundPlaceCheck.position,
            transform.TransformDirection(Vector3.down),
            out hit, 0.3f, groundCheckMask
            ))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
