using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UserMovement : MonoBehaviour
{
    VRTK_ControllerEvents eventHandler;
    VRTK_Pointer pointerHandler;
    VRTK_StraightPointerRenderer cursorSelectPointer;
    VRTK_BezierPointerRenderer teleportPointer;
    VRTK_InteractUse useSetting;
    VRTK_InteractGrab grabSetting;

    void Start()
    {
        eventHandler = GetComponent<VRTK_ControllerEvents>();
        eventHandler.TouchpadPressed += new ControllerInteractionEventHandler(doTouchpadPressed);
        eventHandler.TriggerPressed += new ControllerInteractionEventHandler(doTriggerPressed);
        pointerHandler = GetComponent<VRTK_Pointer>();
        cursorSelectPointer = GetComponent<VRTK_StraightPointerRenderer>();
        teleportPointer = GetComponent<VRTK_BezierPointerRenderer>();
        useSetting = GetComponent<VRTK_InteractUse>();
        grabSetting = GetComponent<VRTK_InteractGrab>();
    }

    private void doTouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        pointerHandler.activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        pointerHandler.selectionButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

        useSetting.enabled = false;
        grabSetting.enabled = false;

        pointerHandler.pointerRenderer = teleportPointer;

        cursorSelectPointer.enabled = false;
        pointerHandler.enableTeleport = true;
        teleportPointer.enabled = true;
     
        pointerHandler.interactWithObjects = false;
        

    }

    private void doTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        pointerHandler.activationButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        pointerHandler.selectionButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        useSetting.enabled = true;
        grabSetting.enabled = true;
        cursorSelectPointer.enabled = true;
        teleportPointer.enabled = false;
        pointerHandler.enableTeleport = false;
        pointerHandler.pointerRenderer = cursorSelectPointer;
        pointerHandler.interactWithObjects = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (eventHandler.men)
        //{
        //    Debug.Log("maro");
        //}
        //if (eventHandler.touchpadPressed)
        //{
        //    pointerHandler.pointerRenderer = teleportPointer;

        //    if (pointerHandler.IsActivationButtonPressed())
        //    {
        //        pointerHandler.activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        //        pointerHandler.selectionButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        //        useSetting.enabled = false;
        //        grabSetting.enabled = false;
        //        pointerHandler.enableTeleport = true;
        //        teleportPointer.enabled = true;

        //        pointerHandler.interactWithObjects = false;
        //        cursorSelectPointer.enabled = false;
        //    }

        //}
        //else
        //{
        //    useSetting.enabled = true;
        //    grabSetting.enabled = true;
        //    pointerHandler.activationButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        //    pointerHandler.selectionButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        //    pointerHandler.enableTeleport = false;
        //    pointerHandler.interactUse = useSetting;
        //    pointerHandler.pointerRenderer = cursorSelectPointer;
        //    pointerHandler.interactWithObjects = true;
        //    cursorSelectPointer.enabled = true;
        //    teleportPointer.enabled = false;
        //}
    }


}
