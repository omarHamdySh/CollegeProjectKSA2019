using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTestData 
{
    public int targetMiss;          //number of the target the user missed 
    public int targetHit;           //number of the target user hit
    public float accuracy;        //the accuracy of the Player on Trainign 
    public string testGPA;       //the GPA of the user Test
    public int shootingRange ;  //the range of shooting the player choose
    public float timeSpent;    //the total time spent in the training 
    public ShootingTestData(int targetMiss,int targetHit,float accureacy,string GPA,int shootingRange,float timeSpent)
    {
        this.targetMiss = targetMiss;
        this.targetHit = targetHit;
        this.accuracy = accureacy;
        this.testGPA = GPA;
        this.shootingRange = shootingRange;
        this.timeSpent = timeSpent;
    }
}
