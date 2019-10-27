using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapOrientationValidator : MonoBehaviour
{
    public Vector3 correctSnapPosition,startSnapPosition;
    public Quaternion correctSnapRotation, startSnapRotation;


    //Original snap order 
    //Start Snapping mechanic position.

    //Remove Child of controller.
    //Freeze Rotation on all axies but Y and postion overall.
    //Capture the rotation of the controller over the local axis that is pointing to the object inteded to rotate
    //and add the rotation angle to the game object over the Y-Axis.
    //Move over the Y-Axis by the a relatively small value.
    //Make the object Kinematic.
    public void Update()
    {

        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y,correctSnapPosition.y,startSnapPosition.y)
            ,transform.position.z);
    }
    


}
