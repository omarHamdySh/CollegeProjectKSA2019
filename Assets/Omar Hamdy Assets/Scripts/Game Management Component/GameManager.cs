using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This is a list of items that would have polmorphic shape and different usage but 
/// The same category.
/// In this application it is a list of weapons.
/// </summary>
public enum GameItemName
{
    MK2 = 1,
    _9MM = 2,
    G36 = 3,
    MP5 = 4,

}
public enum ControllerModesNames
{
    Grab,
    Teleporting,
    UiInteraction,
    HoldFromDistance,
    Grab_Teleporting,
    Grab_UiInteraction,
    Grab_HoldFromDistance,
    Teleporting_UiInterACTION,
    Teleporting_HoldFromDistance,
    UiInteraction_HoldFromDistance,
    Grab_Teleporting_UiInteraction,
    Grab_Teleporting_HoldFromDistance,
    Grab_UiInteraction_HoldFromDistance,
    Teleporting_UiInteraction_HoldFromDistance,
    Grab_Teleporting_UiInteraction_HoldFromDistance
}
/// <summary>
/// Event payload
/// </summary>
/// <param name="timeUnitValue"></param>
public delegate void TimeEvents(float timeUnitValue);
public delegate bool GamePlayStatesEvents(IGameplayState otherState);

[RequireComponent(typeof(GameplayFSMManager), typeof(TimeManager), typeof(SceneMappingManager))]
public class GameManager : MonoBehaviour
{


    #region GameManger Data Memebers 
    private static GameManager _Instance;                               //reference for this script to access it from another place to manage/control his variables and function
    public event TimeEvents OnRealSecondChanged;
    public event TimeEvents OnRealMinuteChanged;
    public event TimeEvents OnGameHourChanged;
    public event TimeEvents OnGameDayChanged;

    public GamePlayStatesEvents OnTransitionHaveToEnd;

    [HideInInspector]
    public TimeManager timeManager;

    [HideInInspector]
    public GameplayFSMManager gameplayFSMManager;                       //reference for the state machine controller to access his state

    [HideInInspector]
    public ItemsSwitcher[] itemsSwitchers;
    //LevelManager
    public bool isTesting;

    public GameItemName currentlySelectedItem;
    public ControllerModesNames currentControlleMode;
    [HideInInspector]
    public ControllerSwitcher[] controllerSwitcher;
    //-------------------------------------------
    #endregion


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
        gameplayFSMManager = GetComponent<GameplayFSMManager>();
        timeManager = GetComponent<TimeManager>();
        SceneManager.sceneLoaded += delegate { OnSceneLoad(); };

    }

    /// <summary>
    ///     Check which game play it is, and position the player at that position.
    ///     Also change the weapon item according to the player choice
    /// </summary>

    public void OnSceneLoad()
    {

    }

    public void updaeGameITemComponent()
    {
        itemsSwitchers = FindObjectsOfType<ItemsSwitcher>();
        switchGameItemTo(this.currentlySelectedItem);

    }


    #region  Gameplay States Global Methods 
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

    /// <summary>
    /// Proceed Transition which means that go to what ever game play state you were 
    /// going before the transition.
    /// </summary>
    public void proceedTransition()
    {
        PauseState nullObj = null;
        bool result = OnTransitionHaveToEnd(nullObj);

        if (result)
        {
            StartCoroutine(turnOfStateFSMHit());
        }

    }

    /// <summary>
    /// Just For the sample scene purpose showing the data reflecting the 
    /// GamePlay FSM component details and how it works.
    /// </summary>
    /// <returns></returns>
    IEnumerator turnOfStateFSMHit()
    {
        yield return new WaitForSeconds(3);
        if (gameplayFSMManager.hintTxt.enabled)
        {
            gameplayFSMManager.hintTxt.enabled = false;
            gameplayFSMManager.hintTxt.text = "";
            gameplayFSMManager.hintTxt.color = Color.white;
        }
    }
    #endregion


    #region Time Periods Related Events 
    /// <summary>
    /// This method will be called by the time manager each second
    /// Functionality:
    ///     it fires the OnSecondChanged Event which will fire every and each method
    ///     That is listening to that event
    /// </summary>

    public void OnSecondChange()
    {
        OnRealSecondChanged(timeManager.gameTime.realSecond);
    }

    /// <summary>
    /// This method will be called by the time manager each minute.
    /// Functionality:
    ///     it fires the OnMinuteChanged Event which will fire every and each method
    ///     That is listening to that event
    /// </summary>
    public void OnMinuteChange()
    {
        OnRealMinuteChanged(timeManager.gameTime.realMinute);
    }

    /// <summary>
    /// This method will be called by the time manager each GameDay.
    /// Functionality:
    ///     it fires the OnGameDayChanged Event which will fire every and each method
    ///     That is listening to that event
    /// </summary>
    public void OnGameDayChange()
    {
        OnGameDayChanged(timeManager.gameTime.gameDay);
    }

    /// <summary>
    /// This method will be called by the time manager each GameHour.
    /// Functionality:
    ///     it fires the OnGameHourChanged Event which will fire every and each method
    ///     That is listening to that event
    /// </summary>
    public void OnGameHourChange()
    {
        OnGameHourChanged(timeManager.gameTime.gameHour);
    }
    #endregion


    #region Game Items Switch Methods
    public void switchGameItemTo(int itemNo)
    {
        foreach (var itemSwitcher in itemsSwitchers)
        {
            itemSwitcher.switchTo(itemNo);
        }
    }
    public void switchGameItemTo(GameItemName itemName)
    {
        foreach (var itemSwitcher in itemsSwitchers)
        {
            itemSwitcher.switchTo(itemName);
        }
    }
  
    public void switchGameItemTo(string itemName)
    {
        foreach (var itemSwitcher in itemsSwitchers)
        {
            itemSwitcher.switchTo(itemName);
        }
    }

    public void setGameItemToSwitchTo(GameItemName itemName)
    {

        this.currentlySelectedItem = itemName;
    }
    public void setGameItemToSwitchTo(int itemNo)
    {

        this.currentlySelectedItem = (GameItemName)itemNo;
    }
    #endregion


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


    #region Controllers Switch Methods
    /// <summary>
    /// 
    /// </summary>
    public void UpdateControllerModes()
        {
            controllerSwitcher = FindObjectsOfType<ControllerSwitcher>();
            SwitchControllerModeTo(this.currentControlleMode);

        }

        public void SwitchControllerModeTo(ControllerModesNames modeName)
        {
            foreach (var controllerMode in itemsSwitchers)
            {
                controllerMode.switchTo(modeName.ToString());
            }
        }
    /// <summary>
    /// /
    /// </summary>
    /// <param name="modeName"></param>
        public void SetControllerModeThatWillSwitchTo(ControllerModesNames modeName)
        {

            this.currentControlleMode = modeName;
        }
    #endregion
}
