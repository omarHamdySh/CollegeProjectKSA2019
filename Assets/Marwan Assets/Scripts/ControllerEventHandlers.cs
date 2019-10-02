namespace VRTK.Examples
{
    using UnityEngine;

    public class ControllerEventHandlers : MonoBehaviour
    {
        [HideInInspector]
        public GameObject rcObject;
        private ObjectController rcCarScript;

        private void Start()
        {
            GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
            GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);
            GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);

            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);
        }

        private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTouchAxis(e.touchpadAxis);

        }
        private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTouchAxis(new Vector2(500, 500));
        }

        private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTriggerAxis(e.buttonPressure);
        }

        private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTouchAxis(Vector2.zero);
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            rcCarScript.SetTriggerAxis(0f);
        }

       
    }
}