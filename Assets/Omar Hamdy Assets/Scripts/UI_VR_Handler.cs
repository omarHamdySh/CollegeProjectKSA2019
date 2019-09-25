using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UI_VR_Handler : MonoBehaviour
{
    private VRTK_InteractableObject Vrscript;
    public GameObject weaponObject;

    UI_VR_Handler[] SwitchWeaponBtnsHandlers;
    
    public int highlightTimeThreshold = 3;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        Vrscript = GetComponent<VRTK_InteractableObject>();
        SwitchWeaponBtnsHandlers = transform.parent.GetComponentsInChildren<UI_VR_Handler>();
    }

    // Update is called once per frame
    void Update()
    {
        countSeconds();
        CheckForSelectionThreshold();
    }

    public void countSeconds() {
        if (Vrscript.enabled)
        {
            seconds += Time.deltaTime;
        }
    }
    private void CheckForSelectionThreshold()
    {
        if ((Vrscript.enabled && (seconds >= highlightTimeThreshold)))
        {
            seconds = 0;
            weaponObject.SetActive(true);
            turnOffOtherWeapons();
        }
    }

    private void turnOffOtherWeapons(){

        if (SwitchWeaponBtnsHandlers != null) 
        {
            foreach (var script in SwitchWeaponBtnsHandlers)
            {
                if (script != this)
                {
                    script.weaponObject.SetActive(false);
                }
            }
        }
    }
}

