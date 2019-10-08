using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitcherButton : MonoBehaviour
{
    public GameItemName itemNameToSwitchTo;

    public void switchToChosenItem() {
        GameManager.Instance.switchGameItemTo(itemNameToSwitchTo);
    }
}
