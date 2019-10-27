﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType1 : MonoBehaviour, IGameItem
{
    public GameItemName itemName;
    
    ItemsSwitcher itemSwitcher;
    public bool CheckAvailableWepaons()
    {
        if (GameManager.Instance.currentLevel == GameLevelsNames.Level_0
          ||GameManager.Instance.currentLevel == GameLevelsNames.Level_1
          ||GameManager.Instance.currentLevel == GameLevelsNames.Level_2)
        {
            return true;
        }
        return false;
    }
    public void switchOn()
    {
        if (CheckAvailableWepaons())
        {
            switchChildrenOn();
            itemSwitcher.switchOtherItemsOff(this);
        }
        
    }

    public void switchOff()
    {
        switchChildrenOff();
        reset();
    }

    private void switchChildrenOff()
    {
        foreach (Transform itemTransform in transform)
        {
            itemTransform.gameObject.SetActive(false);
        }
    }
    private void switchChildrenOn()
    {
        foreach (Transform itemTransform in transform)
        {
            itemTransform.gameObject.SetActive(true);
        }
    }

    void reset() {
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
