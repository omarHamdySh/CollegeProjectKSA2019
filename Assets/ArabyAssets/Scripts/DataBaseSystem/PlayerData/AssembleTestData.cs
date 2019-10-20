using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleTestData
{
    public int  seconds;
    public int minutes;//total time spend in the Test of assemble and deaassble Quize
    public AssembleTestData(int sec,int min)
    {
        this.seconds = sec;
        this.minutes = min;
    }
    public AssembleTestData() { }
}
