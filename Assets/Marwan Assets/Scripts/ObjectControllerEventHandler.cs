namespace VRTK.Examples
{
    using UnityEngine;
    /// <summary>
    /// Event payload
    /// </summary>
    /// <param name="timeUnitValue"></param>
    public delegate void TimeEvents(float timeUnitValue);
    public class ObjectControllerEventHandler : MonoBehaviour
    {
        [HideInInspector]
        private ObjectController rcCarScript;
        private Vector2 touchAxis;
        private float triggerAxis;
        
        GameObject gameobjecController;
        private void Start()
        {
            gameobjecController = GameObject.FindGameObjectWithTag("RightController");

            gameobjecController.GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
            gameobjecController.GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);
            gameobjecController.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);

            gameobjecController.GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            gameobjecController.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);
        }

        private void Update()
        {
            if (GetComponent<VRTK_InteractableObject>().IsTouched())
            {
                Turn();
            }
        }
        private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            touchAxis = e.touchpadAxis;

        }
        private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
        {
            touchAxis = new Vector2(500, 500);
        }

        private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            triggerAxis=e.buttonPressure;
        }

        private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            touchAxis = Vector2.zero;
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            triggerAxis=0f;
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

    }
}