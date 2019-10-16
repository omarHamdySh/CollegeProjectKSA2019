using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _Instance;
    public static LevelManager Instance
    {
        get { return _Instance; }
    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    //this method have to set the player weapon that will used in the current scene
    public void SetCurrentWeapon()
    {
        //Set The current weapon to the player 
    }
    public void SavePreviousData()
    {

    }
}
