using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingData 
{
    // The Type of the weapon the player use
    public Weapon weaponType;
    //List of the player data that will be stored or retrieved from the local file
    public List<ShootingTrainingData> CurrentChangesOnShootingTrainingData;
    public List<ShootingTestData>     CurrentChangesOnShootingTestData;
    //must be Called before  called Store Method to run without any errors
    public void Init()
    {
        CurrentChangesOnShootingTestData = new List<ShootingTestData>();
        CurrentChangesOnShootingTrainingData = new List<ShootingTrainingData>();
    }

    #region Shooting Training Methods
    //Set current Changes in the Training Scene for Specific User
    public void  SetShootingTrainingData(ShootingTrainingData trainingData)
    {
        CurrentChangesOnShootingTrainingData.Add(trainingData);
    }
    //Get alll the user information about Training Shooting
    public void RetreiveTheShootingData()
    {

    }
    //Store The changes happens in the applicatin for spesific user 
    public void StoreShootingTrainingData(PlayerBinaryData player)
    {
        //Devide each
        //if the list not equal null so the player had play the scene 
        //so lets store its data 
        if (CurrentChangesOnShootingTrainingData != null)
        {
            //now we have to divide each object to it's premitives
            //first we have to check if the player first experience VR or not 
            //Make a loopp to check all the possiblites in the future 
            //Yes we will have a single Data per a time but whatever
            for(int i = 0; i < CurrentChangesOnShootingTrainingData.Count; i++)
            {
                //User Data Premitives 
                int hourSpent = player.hourSpent;
                int secondsSpent = player.secondSpent;
                int minutes = player.MinutSpent;
                string userName = player.userName;
                string password = player.password;
                bool isFirstTime = player.firstTimeUseApp;
                //Shooting Trainign Data Premitives
                int range = CurrentChangesOnShootingTrainingData[i].shootingRange;
                int sumResult = CurrentChangesOnShootingTrainingData[i].shootingSumResult;
                int bulletsNO = CurrentChangesOnShootingTrainingData[i].bulletNumbers;
                float accuracy = CurrentChangesOnShootingTrainingData[i].accuracy;
                string GPA = CurrentChangesOnShootingTrainingData[i].shootingAccuracyGPA;
                //Now we have to open Data base connection 

                //Then Make The Insertio 

            }
            
        }
    }
    //public ShootingTrainingData GetTrainingData()
    //{
    //    return shootingTrainingData;
    //}
    #endregion

   //Shooting Test Data 
    #region Shooting Test Methods
    public void SetShootingTestData(ShootingTestData trainingData)
    {

    }
    public void RetreiveShootingTestDataFromLocalFile()
    {

    }
    public void StoreShootingTestData(PlayerBinaryData player)
    {

    }
    //public ShootingTestData GetShootingTestData()
    //{
    //    return shootingTestData;
    //}
    #endregion
}
