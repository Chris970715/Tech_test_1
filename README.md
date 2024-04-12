# Tech_test_1



The following video is the final result.


https://github.com/Chris970715/Tech_test_1/assets/39882035/ba166acb-0768-4887-bb93-e534e020b2bf


On this version, I use Physics.checkSphere to find out whether client is near the door or not.

I set closedRotation to have original position and set rotateTheDoor to have y on 90f. those varaible will be called and used in IF statement.



    void Start()
    {
        // Assigning the orginal posiotn to closedRotation
        closedRotation = transform.localRotation;
        // Assigning targeted direction that the door needs to move
        rotateTheDoor = Quaternion.Euler(0f, 90f, 0f);
    }

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

