using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;                               //reference for this script to access it from another place to manage/control his variables and function

    public GameplayFSMManager gameplayFSMManager;                       //reference for the state machine controller to access his state
    public bool isTesting;

    public static GameManager Instance
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
        DontDestroyOnLoad(this.gameObject);

    }




    /// <summary>
    /// function to pause the scene and all the live scripts in the scene
    /// </summary>
    public void PauseGame()
    {
        #region --deperacted Code
        ///
        /// this code make all scene the scene stop and also the controller functionality
        /// Time.timeScale = 0;
        ///
        #endregion
    }
    /// <summary>
    /// /// <summary>
    /// function to resume the scene and all the live scripts in the scene
    /// </summary>
    /// </summary>
    public void ResumeGame()
    {

        #region --deperacted Code
        ///
        /// this code make all scene the scene stop and also the controller functionality
        /// Time.timeScale = 1;
        ///
        #endregion
    }



    #region Deprecated Leveling code
    /**
    public enum GameLevel {//Must be declared out of the class;
           Level1,
           Level2,
           Level3
    }
     * 
    /// <summary>
    /// this methods returns the index of specific level in the enum
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public int GetLevelIndex(GameLevel level)
    {
        var states = Enum.GetValues(typeof(GameLevel));
        foreach (var item in states)
        {
            if ((GameLevel)item == level)
            {
                return (int)item;
            }
        }
        return -1;
    }
    public void MoveToTheNextLevel()
    {
        currentLevel = (GameLevel)GetLevelIndex(currentLevel) + 1;
        LevelManager.Instance.incrementEnemySpwanTime();

        if (currentLevelInfoLabel)
            currentLevelInfoLabel.text = currentLevel.ToString();

        switch (currentLevel)
        {
            case GameLevel.Level1:
                LevelManager.Instance.enemySpeed = LevelManager.Instance.level1EnemySpeed;

                break;
            case GameLevel.Level2:
                LevelManager.Instance.enemySpeed = LevelManager.Instance.level2EnemySpeed;
                break;
            case GameLevel.Level3:
                LevelManager.Instance.enemySpeed = LevelManager.Instance.level3EnemySpeed;
                break;
            default:
                break;
        }
        if (speedEnemyInfoLabel)
            speedEnemyInfoLabel.text = LevelManager.Instance.enemySpeed.ToString();
    }
    **/
    #endregion
}
