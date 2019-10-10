using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitcherButton : MonoBehaviour
{
    public ControllerModesNames _ControllerModesName;

    public void ChooseControllerMode()
    {
        GameManager.Instance.SwitchControllerModeTo(_ControllerModesName);

    }

    public void SetControllerMode()
    {
        GameManager.Instance.SetControllerModeThatWillSwitchTo(_ControllerModesName);

    }
}
