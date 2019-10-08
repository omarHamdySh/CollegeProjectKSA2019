using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameItem 
{
    void switchOn();
    void switchOff();

    void setSwitcherReference();
    GameItemName getItemName();
}
