using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleTrainingData 
{
    public int timeSpent;    //Total time soent in training 
    public int result;      //the result of the test
    public string GPA;     //the GPA of the current training useing some formula
    public AssembleTrainingData(int time,int result,string gpa)
    {
        this.timeSpent = time;
        this.result = result;
        this.GPA = gpa;
    }
}
