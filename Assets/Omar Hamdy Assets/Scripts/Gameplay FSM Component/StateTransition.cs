using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateTransition : IGameplayState
{
    GameplayState stateName = GameplayState.Transition;

    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
    }
    /// <summary>
    /// Logic of exiting the state goes here.
    ///  Eg.
    ///     pop the currentstate
    ///     push the next state
    /// </summary>
    public void OnStateExit()
    {
    }

    public void OnStateUpdate()
    {
        ////Map to according to the transitionDirection
        //switch (gameplayFSMManager.transitionDirection)
        //{
        //    case StateTransitionDirection.WashingToFighting:
        //        //if there are any clues for the washing process like some paste on the teeth or some effect is still working don't do anything.
        //        //else if there is nothing and everything is clean -> change to the intended state.
        //        if (GameManager.Instance.DirtyTeeth.Count == 0)
        //        {
        //            //AudioSource source = TutorialManager.Instance.EntitiesQueue.Peek().gameObject.GetComponent<AudioSource>();
        //            //TutorialManager.Instance.PlayNextSequence();
        //            //if (!source.isPlaying)
        //            //{
        //            //this mean he clean all the teeth
        //            TutorialManager.Instance.PlayNextSequence();
        //            gameplayFSMManager.ChangeToFighting();
        //            gameplayFSMManager.PushState(gameplayFSMManager.fightingState);
        //            //}
        //        }
        //        break;
        //    case StateTransitionDirection.FightingToWashing:
        //        //if there is any enemy alive wait unil he dies.
        //        //else if there is no enemy alive and everything is clean -> change to the intended state.
        //        GameManager.Instance.enableFightingTools();
        //        if (GameManager.Instance.enemyObjects.All(e1 => e1 == null))
        //        {
        //            TutorialManager.Instance.PlayNextSequence();
        //            gameplayFSMManager.PushState(gameplayFSMManager.washingState);
        //            GameManager.Instance.disableFightingTools();
        //        }
        //        break;
        //    case StateTransitionDirection.WashingToPause:
        //        //if the player click the pause menu and he/she in the washing state
        //        if (GameManager.Instance.DirtyTeeth.Count == 0)
        //        {
        //            //this mean he clean all the teeth
        //            gameplayFSMManager.ChangeToFighting();
        //            gameplayFSMManager.PushState(gameplayFSMManager.fightingState);
        //        }
        //        break;
        //    case StateTransitionDirection.PauseToWashing:
        //        //if the player click the resume menu and back to game again but he/she was in the washing state
        //        gameplayFSMManager.PushState(gameplayFSMManager.washingState);
        //        break;
        //    case StateTransitionDirection.FightingToPause:
        //        //if the player click the pause menu and he/she in the fighting state
        //        GameManager.Instance.enemySpawingPointManager.SetActive(false);
        //        break;
        //    case StateTransitionDirection.PauseToFighting:
        //        //if the player click the resume menu and back to game again but he/she was in the fighting state
        //        GameManager.Instance.enableFightingTools();
        //        break;
        //}
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
