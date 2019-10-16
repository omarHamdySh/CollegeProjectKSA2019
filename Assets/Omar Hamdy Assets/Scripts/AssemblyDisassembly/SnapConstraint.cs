using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void SnapConstraintEvent();

public class SnapConstraint : MonoBehaviour
{
    public SnapConstraintEvent OnSnappingThePrior;
    public SnapConstraintEvent OnConstraintActionDone;
    public SnapOrder snapOrderOfThis;
    private void Start()
    {
        OnConstraintActionDone += DoWhenConstraintActionDone;
        OnSnappingThePrior += DoConstrant;
           
    }

    public void DoWhenConstraintActionDone() {

        //Turn on the Snap Zone Script on the next item.
        snapOrderOfThis.MySnapZone.SetActive(true);

        //and close the s scripts of this object.
        this.enabled = false;
    }
    public void DoConstrant() {
        //Turn off the snap Zone SCript on the next item.
        snapOrderOfThis.MySnapZone.SetActive(false);

        //and close the  snap Order script of this object.

    }

    public void turnConstraintOn()
    {
        OnSnappingThePrior();

    }

    public void turnConstraintOff() {

        OnConstraintActionDone();
    }
}

