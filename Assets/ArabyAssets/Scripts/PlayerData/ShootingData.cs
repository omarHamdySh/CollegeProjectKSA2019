using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingData : MonoBehaviour
{
    // The Type of the weapon the player use
    public Weapon weaponType;
    //List of the player data that will be stored or retrieved from the local file
    public List<ShootingTrainingData> shootingTrainingData;
    public List<ShootingTestData> shootingTestData;
    private void Start()
    {
        shootingTestData = new List<ShootingTestData>();
        shootingTrainingData = new List<ShootingTrainingData>();
    }
    public void  SetShootingTrainingData(ShootingTrainingData trainingData)
    {
        shootingTrainingData.Add(trainingData);
    }
    public void RetreiveTheShootingDataFromLocalFile()
    {

    }
    public void StoreShootingTrainingInFile(List<ShootingTrainingData> allTrainingData)
    {
        //Devide each
    }

}
