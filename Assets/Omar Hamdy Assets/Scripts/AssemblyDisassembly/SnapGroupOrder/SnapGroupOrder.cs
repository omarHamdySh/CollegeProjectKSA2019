using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGroupOrder : MonoBehaviour
{
    public SGO_State state = SGO_State.Waiting;
    public SGO_Manager mySGO_Manager;
    public List<SnapOrder> SGO_Members;
    public bool hasSnapMechanic = false;
    public int myIndex;

    public void Start()
    {
        foreach (var member in SGO_Members)
        {
            member.mySnapGroupOrder = this;
        }
    }

    public enum SGO_State
    {
        Done,//If the SGO is done it won't respond to user interactions.
        InAction,//It is the currently Active SGO and it responds to user interactions.
        Waiting,//Waiting means that this SGO is waiting the previous one to get finished first.
        DoneInAction //If it was the last member in list, it can't be just Done.
    }

    #region Sealed Methods 

    public void putTheNextSGOInAction()
    {
        //Set this SGO state to be Done
        this.state = SGO_State.Done;

        //If there is no next member set the state of this to DoneInAction.
        if (this.myIndex == mySGO_Manager.SGOs.Count - 1)
        {
            mySGO_Manager.currentSGO = this;
            this.state = SGO_State.DoneInAction;
        }
        else
        {   //If there is a next member set the state of the next member to be InAction.
            mySGO_Manager.SGOs[this.myIndex + 1].state = SGO_State.InAction;
            //Disable this snap group members of the previous SGO.
            mySGO_Manager.SGOs[this.myIndex].deactivateThisSGOMemebers();
            //Enable next snap group members of the current SGO.
            mySGO_Manager.SGOs[this.myIndex + 1].activateCurrentSGOMemebers();
            mySGO_Manager.currentSGO = mySGO_Manager.SGOs[this.myIndex + 1];
        }
    }

    public void putThePreviousSGOInAction()
    {

        //Set this SGO state to be Waiting
        this.state = SGO_State.Waiting;

        //If there is no previous members before the first item after base set the state of this member to InAction.
        if (this.myIndex == 1)
        {//Margin
            this.state = SGO_State.InAction;
            mySGO_Manager.currentSGO = this;
        }
        else
        {  //If there is a previous member set the state of the previous member to be InAction.
            mySGO_Manager.SGOs[this.myIndex - 1].state = SGO_State.InAction;
            //Disable this snap group members
            mySGO_Manager.SGOs[this.myIndex].deactivateThisSGOMemebers();
            //Enable previous snap group member
            mySGO_Manager.SGOs[this.myIndex - 1].activateCurrentSGOMemebers();
            mySGO_Manager.currentSGO = mySGO_Manager.SGOs[this.myIndex - 1];
        }


    }

    #endregion

    public void activateCurrentSGOMemebers()
    {
        foreach (var member in SGO_Members)
        {
            member.enabled = true;
        }
    }

    public void deactivateThisSGOMemebers()
    {
        foreach (var member in SGO_Members)
        {
            member.enabled = false;
        }
    }
}
