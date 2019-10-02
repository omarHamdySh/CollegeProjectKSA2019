namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;



    public class ObjectController : MonoBehaviour
    {

        private Vector2 touchAxis;
        private float triggerAxis;
        [HideInInspector]
        public ControllerEventHandlers controllerEvenetHandler;
        GameObject gameobjecController;
        private void Start()
        {
            gameobjecController = GameObject.FindGameObjectWithTag("RightController");
            controllerEvenetHandler = gameobjecController.GetComponent<ControllerEventHandlers>();
        }
        public void SetTouchAxis(Vector2 data)
        {
            touchAxis = data;
        }

        public void SetTriggerAxis(float data)
        {
            triggerAxis = data;
        }

        private void Update()
        {
            if (GetComponent<VRTK_InteractableObject>().IsTouched())
            {
                Turn();
            }

            //if (GetComponent<VRTK_InteractableObject>().)
            //{
            //    controllerEvenetHandler.rcObject = null;
            //    controllerEvenetHandler.enabled = false;
            //}


        }
        public void populateThis()
        {
            //controllerEvenetHandler.enabled = true;
            controllerEvenetHandler.rcObject = gameObject;
            print("This is populated");
        }
        public void unPopulateThis()
        {
            controllerEvenetHandler.rcObject = null;
            print("This is unPopulated");

        }


        private void Turn()
        {
            if (touchAxis != new Vector2(500, 500))
            {

                //transform
                if (touchAxis.x < .5)
                {
                    print("maro < 0.5");
                    gameObject.transform.eulerAngles += new Vector3(0, 5f, 0);
                }

                if (touchAxis.x > -.5)
                {
                    print("maro > 0.5");
                    gameObject.transform.eulerAngles -= new Vector3(0, 5f, 0);
                }

            }
        }

    } //end of the class
} //enf of the namespaces