using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Declare the modes that the controller have to set to like Grabbing , teleporting ,.....

//Start the class controller switcher 
public class ControllerSwitcher : MonoBehaviour
{
    public ControllerItem[] _ControllerModesList;

    // First we collect all the component named as "Controller Item" 
    //Then we attach the right mode to the controller 
    void Start()
    {
        _ControllerModesList = GetComponentsInChildren<ControllerItem>();
        foreach (var item in _ControllerModesList)
        {
            item.setControllerSwitcherReference();
        }
    }

    //second we declare mewthods that the controller switch to 
    //This method set the controller mode when select
    public void SwitchControllerTO(string itemName)
    {
        foreach (var item in _ControllerModesList)
        {
            if (item.getControllerModeName().ToString() == itemName)
            {
                item.ControllerSwitchOn();
                GameManager.Instance._CurrentControllerMode = item.getControllerModeName();
            }
        }    
            
    }
    public void SwitchControllerTO(ControllerModes itemName)
    {
        foreach (var item in _ControllerModesList)
        {
            if (item.getControllerModeName() == itemName)
            {
                item.ControllerSwitchOn();
                GameManager.Instance._CurrentControllerMode = item.getControllerModeName();
            }
        }

    }
    //This Method Turn off the other modes of the controller 
    internal void TurnOffOtherControllerModes(ControllerModes itemToTurnOff) 
    {
        foreach (var item in _ControllerModesList)
        {
            if(item.getControllerModeName() != itemToTurnOff)
            {
                item.ControllerSwitchOff();
            }
        }
    }
}
