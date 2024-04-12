using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientController : MonoBehaviour
{
    [Header("Objects that need to be assigned !")]
    [SerializeField] private CharacterController controller;

    [Header("Settings for clients")] 
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.18f;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 input = transform.right * x + transform.forward * z;
        controller.Move(input * speed * Time.deltaTime);
        
        Gravity();
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
}
