using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingState : IGameplayState
{
    GameplayState stateName = GameplayState.Fighting;
    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public float timeToCheeringperfact = 5f;            // How long between each spawn.
    private float counter = 0;
    public void OnStateEnter()
    {
        //Enable the spawning scripts of the enemies;
        //Turn off the other states' controllers and turn on this state's controller
        TutorialManager.Instance.playThisSequence(TutorialEvent.AttackStarted);
        //GameManager.Instance.enableFightingTools();
        Debug.Log(this.ToString());
    }

    public void OnStateExit()
    {
        /// <summary>
        /// Logic of exiting the state goes here.
        /// Eg.    
        ///     pop the currentstate
        ///     push the next state
        /// other logic related to exiting the this state also goes here
        /// </summary>
        /// 

        //Disable the spawning scripts of the enemies;
        //GameManager.Instance.enemySpawingPointManager.SetActive(false);
        //GameManager.Instance.disableFightingTools();
    }

    public void OnStateUpdate()
    {
        counter += Time.deltaTime;
        if (counter >= timeToCheeringperfact)
        {
            TutorialManager.Instance.playThisSequence(TutorialEvent.CheeringPerfact);
            counter = 0;
        }
    }
    string ToString()
    {
        return stateName.ToString();
    }

    public GameplayState GetState()
    {
        return stateName;
    }
}
