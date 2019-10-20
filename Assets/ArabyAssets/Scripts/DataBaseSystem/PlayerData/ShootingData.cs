//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShootingData 
//{
//    // The Type of the weapon the player use
//    public string weaponName;
//    //List of the player data that will be stored or retrieved from the local file
//    public List<ShootingTrainingData> CurrentChangesOnShootingTrainingData;
//    public List<ShootingTestData>     CurrentChangesOnShootingTestData;
//    //must be Called before  called Store Method to run without any errors
//    public void Init()
//    {
//        CurrentChangesOnShootingTestData = new List<ShootingTestData>();
//        CurrentChangesOnShootingTrainingData = new List<ShootingTrainingData>();
//    }

//    #region Shooting Training Methods
//    //Set current Changes in the Training Scene for Specific User
//    public void  SetShootingTrainingData(ShootingTrainingData trainingData)
//    {
//        CurrentChangesOnShootingTrainingData.Add(trainingData);
//    }
//    //Get alll the user information about Training Shooting
//    public void RetreiveTheShootingData(int id)
//    {

//    }
//    //Store The changes happens in the applicatin for spesific user 
//    public void StoreShootingTrainingData(PlayerBinaryData player)
//    {
//        //Devide each
//        //if the list not equal null so the player had play the scene 
//        //so lets store its data 
//        if (CurrentChangesOnShootingTrainingData != null)
//        {
//            for(int i = 0; i < CurrentChangesOnShootingTrainingData.Count-1; i++)
//            {
//                ////Must save User Data Premitives 
//                DbManager.Instance.Init();
//                DbManager.Instance.AddNewShootingTrainingDataRecord(player.UserId, CurrentChangesOnShootingTrainingData[i]);
//                DbManager.Instance.CloseDataBaseConnection();


//            }
            
//        }
//    }
//    //public ShootingTrainingData GetTrainingData()
//    //{
//    //    return shootingTrainingData;
//    //}
//    #endregion

//   //Shooting Test Data 
//    #region Shooting Test Methods
//    public void SetShootingTestData(ShootingTestData trainingData)
//    {

//    }
//    public void RetreiveShootingTestDataFromLocalFile()
//    {

//    }
//    public void StoreShootingTestData(PlayerBinaryData player)
//    {

//    }
//    //public ShootingTestData GetShootingTestData()
//    //{
//    //    return shootingTestData;
//    //}
//    #endregion
//}
