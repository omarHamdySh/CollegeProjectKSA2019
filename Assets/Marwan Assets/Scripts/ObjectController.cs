using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector2 touchAxis;

    public void SetTouchAxis(Vector2 data)
    {
        touchAxis = data;
    }

    private void Update()
    {
        RotateObject();
    }
    void RotateObject()
    {
        //print("maro el soghir l2 yetmal");
        if (touchAxis != new Vector2(500, 500))
        {
            ////// Rotation 
            if (transform.rotation.x < 180 && transform.rotation.y < 180 && transform.rotation.z < 180)
            {
                if (touchAxis.x > .7)
                {
                    transform.Rotate(0, -1f, 0, 0);


                }
            }
            if (transform.localScale.x > -180 && transform.localScale.y > -180 && transform.localScale.z > -180)
            {
                if (touchAxis.x < -.7)
                {
                    transform.Rotate(0, 1f, 0, 0);

                }
            }
        }
    }
}
