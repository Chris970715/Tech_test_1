using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorController : MonoBehaviour
{

    [Header("Objects that I need to assign for door")] 
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform collitionDetect;
    [SerializeField] private CharacterController characterController;

    [Header("Setting for the door")] 
    [SerializeField] private float distance = 1f;
    [SerializeField] private float doorSensitivity = 5f;
    
    private bool isTouched;
    private Quaternion rotateTheDoor;
    private Quaternion closedRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        // Assigning the orginal posiotn to closedRotation
        closedRotation = transform.localRotation;
        // Assigning targeted direction that the door needs to move
        rotateTheDoor = Quaternion.Euler(0f, 90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Detect whether the object is in range where the door object can open or not
        isTouched = Physics.CheckSphere(collitionDetect.position, distance, _layerMask);

        // If the client is in the zone, the door will open 
        if (isTouched)
        {
            // moving the door to the targeted direction 
            transform.localRotation =
                Quaternion.Lerp(transform.localRotation, rotateTheDoor, Time.deltaTime * doorSensitivity);
            
        }
        // If not It will go back to the original position
        else
        {
            isTouched = false;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, closedRotation, Time.deltaTime * doorSensitivity);
        }
    }
}
