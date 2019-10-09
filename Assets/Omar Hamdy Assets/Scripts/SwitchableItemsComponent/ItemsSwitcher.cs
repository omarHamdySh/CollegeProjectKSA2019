using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameItemType {
    AssemblyDisassembly,
    Shooting,
    Tutorial
}
public class ItemsSwitcher : MonoBehaviour
{
    public IGameItem[] itemsList;
    // Start is called before the first frame update
    void Start()
    {
        itemsList = GetComponentsInChildren<IGameItem>();
        foreach (var item in itemsList)
        {
            item.setSwitcherReference();
        }
    }
    public void switchTo(string ItemName) {

        foreach (var item in itemsList)
        {
            if (ItemName == item.getItemName().ToString())
            {
                item.switchOn();
                GameManager.Instance.currentlySelectedItem = item.getItemName();
            }
        }
    }
    public void switchTo(int itemNo) {

        foreach (var item in itemsList)
        {
            if (itemNo == (int)item.getItemName())
            {
                item.switchOn();
                GameManager.Instance.currentlySelectedItem = item.getItemName();

            }
        }
    }
    public void switchTo(GameItemName ItemName) {

        foreach (var item in itemsList)
        {
            if (ItemName == item.getItemName())
            {
                item.switchOn();
                GameManager.Instance.currentlySelectedItem = item.getItemName();

            }
        }
    }
    internal void switchOtherItemsOff(IGameItem switchedOnItem)
    {
        foreach (var item in itemsList)
        {
            if (item != switchedOnItem)
            {
                item.switchOff();
            }
        }
    }

}
