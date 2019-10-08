using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType3 : MonoBehaviour,IGameItem
{

    public GameItemName itemName;
    ItemsSwitcher itemSwitcher;


    public void switchOn()
    {
        gameObject.SetActive(true);
        itemSwitcher.switchOtherItemsOff(this);
    }

    public void switchOff()
    {
        gameObject.SetActive(false);
        reset();
    }

    void reset()
    {
        //Reset Logic goes here
        //i.e. position, rotation etc.
    }
    public GameItemName getItemName()
    {
        return itemName;
    }

    public void setSwitcherReference()
    {
        itemSwitcher = GetComponentInParent<ItemsSwitcher>();
    }
}
