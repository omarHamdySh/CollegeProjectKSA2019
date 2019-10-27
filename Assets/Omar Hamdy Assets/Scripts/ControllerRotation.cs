using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ControllerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool flag = true;

    private VRTK_InteractableObject AssemblyObject;

    public SnapOrder AssemblyObjSnapOrder;

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = Quaternion.identity;
        Quaternion newRotationy = Quaternion.identity;
        newRotation.x = transform.rotation.x;
        newRotationy.y = transform.rotation.y;


        float rotationOnZ = transform.eulerAngles.z;

        float rotationOnX = transform.eulerAngles.x;

        if (!AssemblyObject)
        {
            return;
        }


        if (AssemblyObject.IsTouched() && AssemblyObjSnapOrder.snapFlag == SnapOrder.SnapOrderFlag.SNAPPED)
        {
            AssemblyObject.transform.parent = null;
            AssemblyObject.transform.gameObject.GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            if (Between(rotationOnX, -30, 30))
            {

            }
            else if (Between(rotationOnX, 60, 120))
            {

            }
        }
        else
        {

        }



        if ((rotationOnZ > 130) && (rotationOnZ <= 230))
        { }
        else
        {
            if (AssemblyObject.IsGrabbed())
            {

            }
            else
            {

            }
        }

    }
    public static bool Between(float number, float min, float max)
    {
        return number >= min && number <= max;
    }

}
