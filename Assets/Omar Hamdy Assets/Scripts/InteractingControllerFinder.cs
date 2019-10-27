using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractingControllerFinder : MonoBehaviour
{
    public GameObject interActingController;
    public ControllerRotation controllerRotation;
    public VRTK_InteractableObject interactableObject;
    public ControllerRotation[] controllerRotations;
    void Start()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectGrabbed += GetCurrentGrabedController;
    }

    public void GetCurrentGrabedController(object sender, InteractableObjectEventArgs e)
    {
        interActingController = interactableObject.grabbingObjects[0].gameObject;
        controllerRotation = interActingController.GetComponentInParent<ControllerRotation>();
        controllerRotation.AssemblyObjSnapOrder = GetComponent<SnapOrder>();
    }
}
