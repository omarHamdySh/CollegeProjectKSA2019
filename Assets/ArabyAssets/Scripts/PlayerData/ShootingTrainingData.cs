using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrainingData 
{
    public int shootingRange;               //the shooting range the player choose during training 
    public int bulletNumbers;              //the bullet number the player shoot 
    public float accuracy;                //player accuracy in hitting the targets in numbers
    public string shootingAccuracyGPA;   //shooting accuracy in GPA for hitting the tragets
    public int shootingSumResult;       //the total sum of the shooting 
    public ShootingTrainingData(int range,int bulletNumber,float accuracy,string GPA,int shootingResultSum)
    {
        this.shootingAccuracyGPA = GPA;
        this.shootingRange = range;
        this.shootingSumResult = shootingResultSum;
        this.accuracy = accuracy;
        this.bulletNumbers = bulletNumber;
    }
}
