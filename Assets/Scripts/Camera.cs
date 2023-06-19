using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class: Camera
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. speed: speed of camera 

    Methods: 

    a. Update()
*/

public class Camera : MonoBehaviour
{
    public float speed = 1.5f;

   
    /*
        Method: Update()
        Visibility: Private() 
        Output: N/A
        Purpose: 

        a. Finds Horizontal Axis 
        b. Finds Vertical Axis 
        c. Creates a new Vector for Camera including Horizontal and Vertical 
        d. tempVect equals tempVect normalized * speed * time 
        e. moves camera to tempVect
    */  

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        transform.position += tempVect;
    }
}
