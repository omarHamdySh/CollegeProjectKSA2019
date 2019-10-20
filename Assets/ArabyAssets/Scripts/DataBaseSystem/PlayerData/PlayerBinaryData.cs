using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBinaryData : MonoBehaviour
{

    #region Golobal Prametrs
    //User name and password we will check it from local saved file
    public int UserId = 0;
    public string userName;
    public string password;
    public bool firstTimeUseApp=true;
    //these variable calculate the sum of time spent in training and test for the user
    public int hourSpent;
    public int secondSpent;
    public int MinutSpent;
  //List of the player data that will be stored or retrieved from the local file
    public ShootingTrainingData CurrentChangesOnShootingTrainingData=null;
    public ShootingTestData CurrentChangesOnShootingTestData=null;
    public AssembleTestData CurrentChangesOnAssemblyTestData = null;
    public AssembleTrainingData CurrentChangesOnAssemblyTraining = null;
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
    public void StoreTrainingShootingDataForUser(int range, int bulletNumber, float accuracy, string GPA, int shootingResultSum)
    {
        ShootingTrainingData sh = new ShootingTrainingData(range, bulletNumber, accuracy, GPA, shootingResultSum);
        DbManager.Instance.AddNewShootingTrainingDataRecord(UserId,sh);
    }
    //Test Data sent to Trainig class to store 
    public void StoreTestShootingDataForUser(int targetMiss, int targetHit, float accureacy, string GPA, int shootingRange, int min, int sec)
    {
        ShootingTestData sh = new ShootingTestData(targetMiss, targetHit, accureacy, GPA, shootingRange, min, sec);
        DbManager.Instance.AddNewShootingTestDataRecord(UserId, sh);
    }
    //Save all the current data that user change during Play the application 
    #endregion


    #region Assembly Methods
    public void StoreTestAssemblyDataForUser(int seconds,int minutes)
    {
        AssembleTestData sh = new AssembleTestData(seconds, minutes);
        DbManager.Instance.AddNewAssemblyTestDataRecord(UserId,sh);
    }
    public void StoreTraingingAssemblyDataForUser(int min, int sec, int result, string gpa)
    {
        AssembleTrainingData sh = new AssembleTrainingData(min,sec,result, gpa);
        DbManager.Instance.AddNewAssemblyTrainingDataRecord(UserId, sh);
    }
    public List<AssembleTestData> GetAssemblyTestRecordsForcUser()
    {
      List<AssembleTestData> tests = DbManager.Instance.GetAssemblyTestRecord(UserId);
        return tests;
    }
    public List<AssembleTrainingData> GetAssemblyTrainingRecordsForUser()
    {
        List<AssembleTrainingData>  sh = DbManager.Instance.GetAssemblyTrainingRecord(UserId);
        return sh;
    }
    #endregion
}
