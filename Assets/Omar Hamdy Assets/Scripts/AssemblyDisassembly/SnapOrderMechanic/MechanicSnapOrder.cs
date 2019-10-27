using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicSnapOrder : SnapOrder
{
    public SnapOrder originalSnapOrder;                      //
    public List<GameObject> mechanicSnapOrders;              //The new snap order chain 
    public void Start()
    {
        this.originalSnapOrder = GetComponent<SnapOrder>();
    }

    public void disableSnapOrder()
    {
        originalSnapOrder.enabled = false;
    }

    public void enableSnapOrder() {
        originalSnapOrder.enabled = true;
    }


    //If this is the last snap order in the snap order chain.
    //Lets 
}
