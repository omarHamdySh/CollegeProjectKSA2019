using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameLevelsNames currentLevel;

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

    public void ChangeToNextScene()
    {

    }
    public void StoreRecordsOfCurrentScene(SceneName sceneName)
    {
        //Must Set flag isTraining in PlayerBinary class to true if player enter training mode
        switch (sceneName)
        {
            
            case SceneName.Main:
                {
                
                    break;
                }
            case SceneName.ShootingScene:
                {
                   
                    break;
                }
            case SceneName.Testing:
                {

                    break;
                }
            case SceneName.UIScene:
                {

                    break;
                }
            case SceneName.VRTutorial:
                {

                    break;
                }
        }
    }
  
}
