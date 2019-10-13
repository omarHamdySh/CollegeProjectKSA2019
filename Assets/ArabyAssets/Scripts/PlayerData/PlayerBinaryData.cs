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
    public List<ShootingData> shootingData;
    public List<AssembleData> assembleData;
}
