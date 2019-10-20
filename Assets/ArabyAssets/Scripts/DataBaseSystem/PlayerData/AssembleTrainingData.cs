using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleTrainingData 
{
    public int minutes;    //Total time soent in training 
    public int result;      //the result of the test
    public string GPA;     //the GPA of the current training useing some formula
    public int seconds;
    public AssembleTrainingData(int min,int sec,int result,string gpa)
    {
        this.minutes = min;
        this.result = result;
        this.GPA = gpa;
        this.seconds = sec;
    }
    public AssembleTrainingData() { }
}
