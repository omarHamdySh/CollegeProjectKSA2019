using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ControllerItem
{
    void ControllerSwitchOn();
    void ControllerSwitchOff();

    void setControllerSwitcherReference();
    ControllerModes getControllerModeName();
}
