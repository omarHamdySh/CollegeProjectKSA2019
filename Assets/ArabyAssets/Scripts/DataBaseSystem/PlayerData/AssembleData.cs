//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AssembleData : MonoBehaviour
//{
//    public string weaponName;    // The Type of the weapon the player use
//    //List of the player data that will be stored or retrieved from the local file
//    public List<AssembleTestData>     CurrentChanesOnAssembleTestData;
//    public List<AssembleTrainingData> CurrentChanesOnAssembleTrainingData;
//    //must be Called before  called Store Method to run without any errors
//    public void Init()
//    {
//        CurrentChanesOnAssembleTestData = new List<AssembleTestData>();
//        CurrentChanesOnAssembleTrainingData = new List<AssembleTrainingData>();
//    }
//    #region Assemble Training Methods
//    //Set current Changes in the Training Scene for Specific User
//    public void SetShootingTrainingData(AssembleTrainingData trainingData)
//    {
//        CurrentChanesOnAssembleTrainingData.Add(trainingData);
//    }
//    //Get alll the user information about Training Assemble
//    public void RetreiveTheShootingData()
//    {

//    }
//    //Store The changes happens in the applicatin for spesific user 
//    public void StoreShootingTrainingData(PlayerBinaryData player)
//    {
//        //Devide each
//        //if the list not equal null so the player had play the scene 
//        //so lets store its data 
//        if (CurrentChanesOnAssembleTrainingData != null)
//        {
//            //now we have to divide each object to it's premitives
//            //first we have to check if the player first experience VR or not 
//            //Make a loopp to check all the possiblites in the future 
//            //Yes we will have a single Data per a time but whatever
//            for (int i = 0; i < CurrentChanesOnAssembleTrainingData.Count; i++)
//            {
//                //User Data Premitives 
//                int hourSpent = player.hourSpent;
//                int secondsSpent = player.secondSpent;
//                int minutes = player.MinutSpent;
//                string userName = player.userName;
//                string password = player.password;
//                bool isFirstTime = player.firstTimeUseApp;
//                //Shooting Trainign Data Premitives
//                int timeSpent = CurrentChanesOnAssembleTrainingData[i].minutes;
//                int result = CurrentChanesOnAssembleTrainingData[i].result;
//                string gpa = CurrentChanesOnAssembleTrainingData[i].GPA;
//                //Now we have to open Data base connection 

//                //Then Make The Insertio 

//            }

//        }
//    }
//        #endregion
//    }
