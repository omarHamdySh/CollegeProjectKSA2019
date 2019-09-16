using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SnapOrderManager : MonoBehaviour
{


    [Tooltip("Here you must insert all the snappable objects in ordered their right order (Snap Order List), will be ordered according to the insertion order. \nRequired: true")]
    public List<SnapOrder> snapOrderObjects;               //Snap objects list that retain the order of the snapping

    [HideInInspector]
    public int currentRingIndex;                           //The current chain's ring index in the snap order chain.


    public void OnSnap(object sender, SnapDropZoneEventArgs e)
    {
        snapOrderObjects[currentRingIndex].OnSnappingThis();
    }

    public void OnUnSnap(object sender, SnapDropZoneEventArgs e)
    {
        snapOrderObjects[currentRingIndex].OnUnSnappingThis();
    }
}
