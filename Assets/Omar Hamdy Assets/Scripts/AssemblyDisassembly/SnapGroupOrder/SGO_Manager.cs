using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGO_Manager : MonoBehaviour
{
    public List<SnapGroupOrder> SGOs;
    public SnapGroupOrder currentSGO;

    private void Start()
    {
        Init();

    }

    private void Init()
    {
        SGOs[0].state = SnapGroupOrder.SGO_State.InAction;

        SGOs[0].activateCurrentSGOMemebers();

        currentSGO = SGOs[0];

        int snapOrderIndexer = 0;

        foreach (SnapGroupOrder SGO in SGOs)
        {

            SGO.mySGO_Manager = this;

            SGO.myIndex = SGOs.IndexOf(SGO);

            foreach (SnapOrder snapOrder in SGO.SGO_Members)
            {

                snapOrder.thisSnapOrderIndex = snapOrderIndexer++;

                snapOrder.AssemblyBase = SGOs[0].SGO_Members[0];
            }
        }
        SGOs[0].SGO_Members[0].SwitchSnapAreasOn();   //enable the assembly Base snap child snap areas.
        InitOnTheDefualtState();                      //Deactivate every other snap group order members but the current's.
    }

    public void InitOnTheDefualtState()
    {
        //int firstAfterBaseGroup=0;                  //The index of the group that contains the first part after the bese part. 
        //foreach (SnapGroupOrder SGO in SGOs)
        //{
        //    SnapOrder temp= SGO.SGO_Members.Find(snapOrder => snapOrder.thisSnapOrderIndex == 1); // Get the snap order with the index 1 if any
        //    if (temp) // if temp is not empty then this SGO contains the snap order of index 1;
        //    {
        //        firstAfterBaseGroup = SGOs.IndexOf(SGO);    //Getting the SGO index in SGOs List.

        //        if (firstAfterBaseGroup !=0)    // if the SGO is not equal to zero this means that the 1st part after the base is not at the first SGO.
        //        {
        //            SGO.state = SnapGroupOrder.SGO_State.InAction; //We will put the SGO that Contains our intended part InAction.
        //            SGO.activateCurrentSGOMemebers();              //
        //        }
        //    }
        //}
                
        foreach (var SGO in SGOs)
        {
            if (SGO != currentSGO  /*&&  SGO!= SGOs[firstAfterBaseGroup]*/)
            {
                SGO.deactivateThisSGOMemebers();
            }

        }
    }
    public void moveToNextMember()
    {
        currentSGO.putTheNextSGOInAction();
    }

    public void moveToPreviousMemeber()
    {
        currentSGO.putThePreviousSGOInAction();
    }
}
