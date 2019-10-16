using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBinaryData : MonoBehaviour
{
    //User name and password we will check it from local saved file
    public string userName;
    public string password;
    public bool firstTimeUseApp=true;
    //these variable calculate the sum of time spent in training and test for the user
    public int hourSpent;
    public int secondSpent;
    public int MinutSpent;
    // This two variable will be get from the saved file
    public ShootingData shootingData;
    public AssembleData assembleData;
    public bool isEnterShoootingMode = false;   //Detect if the player enter shooting mode to calculate 
    public bool isEnterAssembleMode = false;   //Detect if the player enter Assemble mode to calculate 
    public bool isLeavingShootingMode = false;//Detect if the player leave shooting to save its data
    public bool isLeavingAssembleMde = false;//detect if the player leave assemble to save it's data

    #region Shooting Data Methods
    //Genral Methods For Shooting Data That will retreive the data and store it for spesific user
    //Get All the Shooting Data for the User 
    public void GetShootingDataForSpecificUser()
    {

    }
    //Save all the current data that user change during Play the application 
    public void SaveChangedDataForSpecificUser()
    {
        if (isLeavingShootingMode)
        {
            shootingData.Init();
            if(shootingData.CurrentChangesOnShootingTrainingData!=null)
                shootingData.StoreShootingTrainingData(this);
            if(shootingData.CurrentChangesOnShootingTestData!=null)
                shootingData.StoreShootingTestData(this);
        }
        else if (isLeavingAssembleMde)
        {
            //the same like Training00
        }
    }
    //Set Shoooting Test Data 
    //Send All the Data for it's class to handle it 
    //Training Data sent to Trainig class to store 
    public void SetTrainingShootingDataForSpecificUser(ShootingTrainingData trainignData)
    {
        shootingData.SetShootingTrainingData(trainignData);
    }
    //Test Data sent to Trainig class to store 
    public void SetTestShootingDataForSpecificUser(ShootingTestData testdata)
    {
        shootingData.SetShootingTestData(testdata);
    }

    #endregion
}
