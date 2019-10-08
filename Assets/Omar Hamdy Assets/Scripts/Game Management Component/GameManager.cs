using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public enum GameItemName
{
    MK2 = 1,
    _9MM = 2,
    G36 = 3,
    MP5 = 4,

}
/// <summary>
/// Event payload
/// </summary>
/// <param name="timeUnitValue"></param>
public delegate void TimeEvents(float timeUnitValue);
public delegate bool GamePlayStatesEvents(IGameplayState otherState);

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;                               //reference for this script to access it from another place to manage/control his variables and function
    public event TimeEvents OnRealSecondChanged;
    public event TimeEvents OnRealMinuteChanged;
    public event TimeEvents OnGameHourChanged;
    public event TimeEvents OnGameDayChanged;

    public GamePlayStatesEvents OnTransitionHaveToEnd;

    public TimeManager timeManager;
    public GameplayFSMManager gameplayFSMManager;                       //reference for the state machine controller to access his state
    [HideInInspector]
    public ItemsSwitcher[] itemsSwitchers;
    //LevelManager
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

    private void Start()
    {
        OnSceneLoad();
        SceneManager.sceneLoaded += delegate { OnSceneLoad(); };
    }

    /// <summary>
    /// function to pause the scene and all the live scripts in the scene
    /// </summary>
    public void PauseGame()
    {
        gameplayFSMManager.pauseGame();
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
        gameplayFSMManager.resumeGame();
        #region --deperacted Code
        ///
        /// this code make all scene the scene stop and also the controller functionality
        /// Time.timeScale = 1;
        ///
        #endregion
    }

    public void resetGame()
    {

    }

    public void proceedTransition()
    {
        PauseState nullObj = null;
        bool result=  OnTransitionHaveToEnd(nullObj);

        if (result)
        {
            StartCoroutine(turnOfStateFSMHit());
        }

    }

    IEnumerator turnOfStateFSMHit() {
        yield return new WaitForSeconds(3);
        if (gameplayFSMManager.hintTxt.enabled)
        {
            gameplayFSMManager.hintTxt.enabled = false;
            gameplayFSMManager.hintTxt.text = "";
            gameplayFSMManager.hintTxt.color = Color.white;
        }
    }

    public void OnSecondChange()
    {
        OnRealSecondChanged(timeManager.gameTime.realSecond);
    }

    public void OnMinuteChange()
    {
        OnRealMinuteChanged(timeManager.gameTime.realMinute);
    }

    public void OnGameDayChange()
    {
        OnGameDayChanged(timeManager.gameTime.gameDay);
    }

    internal void OnGameHourChange()
    {
        OnGameHourChanged(timeManager.gameTime.gameHour);
    }

    public void switchGameItemTo(int itemNo) {
        foreach (var itemSwitcher in itemsSwitchers)
        {
            itemSwitcher.switchTo(itemNo);
        }
    }
    /// <summary>
    ///     Check which game play it is, and position the player at that position.
    ///     Also change the weapon item according to the player choice
    /// </summary>
    public void OnSceneLoad() {
        itemsSwitchers = FindObjectsOfType<ItemsSwitcher>();

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
