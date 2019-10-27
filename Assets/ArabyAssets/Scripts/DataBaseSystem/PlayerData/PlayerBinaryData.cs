using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBinaryData : MonoBehaviour
{

    #region Comments Prametrs
    //public string userName;
    //public string password;
    //public bool firstTimeUseApp = true;
    //these variable calculate the sum of time spent in training and test for the user
    //public int hourSpent;
    //public int secondSpent;
    //public int MinutSpent;
    //List of the player data that will be stored or retrieved from the local file
    //User name and password we will check it from local saved file
    #endregion


    #region Golobal Prametrs
    public int UserId = 0;

    public ShootingTrainingData CurrentChangesOnShootingTrainingData = null;
    public ShootingTestData CurrentChangesOnShootingTestData = null;
    public AssembleTestData CurrentChangesOnAssemblyTestData = null;
    public AssembleTrainingData CurrentChangesOnAssemblyTraining = null;
    public int currentScore = 0;
    public bool isTraining = false;
    #endregion


    #region SINGLETON 
    private static PlayerBinaryData _Instance;                               //reference for this script to access it from another place to manage/control his variables and function

    public static PlayerBinaryData Instance
    {
        get { return _Instance; }

    }

    private void Awake()
    {
        /** Order of methods calling is critical**/
        if (_Instance == null)
        {
            _Instance = this;
        }
    }
    #endregion


    #region Shooting Data Methods
    public List<ShootingTrainingData> GetShootingTrainingDataForSpecificUser(int id)
    {
        List<ShootingTrainingData> shootingadata = DbManager.Instance.GetShootingTrainingRecord(id);
        return shootingadata;
    }
    public List<ShootingTestData> GetShootingTestDataForSpecificUser(int id)
    {
        List<ShootingTestData> shootingadata = DbManager.Instance.GetShootingTestRecords(id);
        return shootingadata;
    }
    //Set All the Shooting Data fot the User
    public void StoreTrainingShootingDataForUser()
    {
        DbManager.Instance.AddNewShootingTrainingDataRecord(UserId, CurrentChangesOnShootingTrainingData);
    }
    //Test Data sent to Trainig class to store 
    public void StoreTestShootingDataForUser()
    {
        DbManager.Instance.AddNewShootingTestDataRecord(UserId, CurrentChangesOnShootingTestData);
    }
    //Save all the current data that user change during Play the application 
    #endregion


    #region Assembly Methods
    public void StoreTestAssemblyDataForUser()
    {
        DbManager.Instance.AddNewAssemblyTestDataRecord(UserId, CurrentChangesOnAssemblyTestData);
    }
    public void StoreTraingingAssemblyDataForUser()
    {
        DbManager.Instance.AddNewAssemblyTrainingDataRecord(UserId, CurrentChangesOnAssemblyTraining);
    }
    public List<AssembleTestData> GetAssemblyTestRecordsForcUser()
    {
        List<AssembleTestData> tests = DbManager.Instance.GetAssemblyTestRecord(UserId);
        return tests;
    }
    public List<AssembleTrainingData> GetAssemblyTrainingRecordsForUser()
    {
        List<AssembleTrainingData> sh = DbManager.Instance.GetAssemblyTrainingRecord(UserId);
        return sh;
    }
    #endregion
    #region deprecated
    //public void StorePlayerData()
    //{
    //    if (isTraining)
    //    {
    //        if (CurrentChangesOnShootingTrainingData != null)
    //        {
    //            StoreTrainingShootingDataForUser();
    //        } else if (CurrentChangesOnAssemblyTraining != null) {
    //            StoreTraingingAssemblyDataForUser();
    //        }
    //    }
    //    else
    //    {
    //        if (CurrentChangesOnAssemblyTestData != null)
    //        {
    //            StoreTestAssemblyDataForUser();
    //        }
    //        else if (CurrentChangesOnShootingTestData != null)
    //        {
    //            StoreTestShootingDataForUser();
    //        }
    //    }
    //    CurrentChangesOnShootingTrainingData = null;
    //    CurrentChangesOnShootingTestData = null;
    //    CurrentChangesOnAssemblyTestData = null;
    //    CurrentChangesOnAssemblyTraining = null;
    //}
    #endregion
}



