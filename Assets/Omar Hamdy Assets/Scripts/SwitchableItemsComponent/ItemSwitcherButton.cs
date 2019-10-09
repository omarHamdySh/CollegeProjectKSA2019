using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitcherButton : MonoBehaviour
{
    public GameItemName itemNameToSwitchTo;

    /// <summary>
    /// This method must be only used when the Game Item list exist in the scene AKA GameItem Prefabs Component.
    /// </summary>
    public void switchToChosenItem() {//Directly Switch the weapon
        GameManager.Instance.switchGameItemTo(itemNameToSwitchTo);
    }
    /// <summary>
    /// This method must be only used when ever the Game Item list don't exist in the scenne.
    /// Level1 is just introduction and UI level.
    /// We need to postpone switching to the chosen prefab in level1 until level2 is loaded.
    /// so we will set the currentSelectedItem in the game manager to the chosen item.
    /// at level2 the game manager will switch to the game item when the Game Items list exist.
    /// 
    /// </summary>
    public void setChosenItemToSwitch() {//set the game item to switch to and delegate the game manager to switch to in the proper scene
        GameManager.Instance.setGameItemToSwitchTo(itemNameToSwitchTo);
    }
}
