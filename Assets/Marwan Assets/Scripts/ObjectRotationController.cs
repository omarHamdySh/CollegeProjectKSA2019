using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ObjectRotationController : MonoBehaviour
{
    public GameObject rcCar;
    private ObjectController mObjectController;

    private void Start()
    {
        mObjectController = rcCar.GetComponent<ObjectController>();
        //GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
        GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);
        GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);


        // GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
        GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);

        //GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoCarReset);
    }

    private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        print("DoTouchpadAxisChanged");
        mObjectController.SetTouchAxis(e.touchpadAxis);

    }
    private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
    {
        print("DoTouchpadReleased");

        mObjectController.SetTouchAxis(new Vector2(500, 500));
    }



    private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        print("DoTouchpadTouchEnd");

        mObjectController.SetTouchAxis(Vector2.zero);
    }

    #region code function don't use it
    //private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    //{
    //    rcCarScript.SetTriggerAxis(e.buttonPressure);
    //}

    //private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
    //{
    //    rcCarScript.SetTriggerAxis(0f);
    //}

    //private void DoCarReset(object sender, ControllerInteractionEventArgs e)
    //{
    //    if (rcCar.activeSelf)
    //    {
    //        Debug.Log("heratrest");

    //        rcCarScript.ResetCar();
    //    }
    //}
#endregion
}
