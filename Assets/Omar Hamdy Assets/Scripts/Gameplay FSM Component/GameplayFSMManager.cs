using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// define the gamepaly states
/// Transition state controls the the transition between two states
/// washing state which the player clean the teeth after bacterias attack it (teeth)
/// fighting state which the start state of the player where he/she defends opposite bacteria
/// pause state which controling the pause status for opening/closing the menu
/// </summary>
public enum GameplayState
{
    Tutorial,
    AssemblyDisassembly,
    AssemblyDisassemblyTutorial,
    Shooting,
    Testing,
    Transition,
    Pause
}
/// <summary>
/// state transtition which controling the direction of the state 
/// and which state should pass to the second
/// six probabilities for the transtition states
/// Creation form:
///     FromState1ToState2;
///     FromState2ToState1;
///     FromState1ToState3;
///     FromState3ToState1;
///     FromState2ToState3;
///     FromState3ToState2;
/// </summary>
public enum StateTransitionDirection
{
}
public class GameplayFSMManager : MonoBehaviour
{
    //Debug Variables
    public TextMeshProUGUI currentStateTxt;

    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// Eg.
    ///     public int chasingRange;
    ///     public int shootingRange;
    ///     public int alertRange;
    /// </summary>
    //define the stack which controlling the current state
    Stack<IGameplayState> stateStack = new Stack<IGameplayState>();

    /// <summary>
    /// Declaration of states Instances goes here.
    /// </summary>

    [HideInInspector]
    public AssemblyDissassemblyState assemblyDissassemblyState;
    [HideInInspector]
    public AssemblyDisAssemblyTutorialState assemblyDisAssemblyTutorialState;
    [HideInInspector]
    public ShootingState shootingState;
    [HideInInspector]
    public TestingState testingState;
    [HideInInspector]
    public TutorialState tutorialState;
    [HideInInspector]
    public StateTransition stateTransition;
    [HideInInspector]
    public PauseState pauseState;
    //define a temp to know which the state the player come from it to pause state
    [HideInInspector]
    public IGameplayState tempFromPause;
    //define the varaible of the direction of the states 
    [HideInInspector]
    public StateTransitionDirection transitionDirection;

    /// <summary>
    /// Declaration of references will be used for the states logic goes here
    /// Eg. 
    ///     public ISteer steeringScript;
    ///     public GameObject pathRoute;
    ///     public Queue<GameObject> enemyQueue = new Queue<GameObject>();
    /// 
    /// </summary>
    private void Start()
    {
        /// <summary>
        /// Instantiation of states Instances goes here.
        /// Eg.
        /// chaseEnemy = new ChaseState()
        ///        {
        ///     chasingRange = this.chasingRange,
        ///     shootingRange = this.shootingRange,
        ///     alertRange = this.alertRange,
        ///     movementController = this
        ///         };
        /// </summary>

        ////Instantiate the first state
        assemblyDissassemblyState = new AssemblyDissassemblyState()
        {
            gameplayFSMManager = this
        };

        assemblyDisAssemblyTutorialState = new AssemblyDisAssemblyTutorialState()
        {
            gameplayFSMManager = this
        };

        shootingState = new ShootingState()
        {
            gameplayFSMManager = this
        };

        testingState = new TestingState()
        {
            gameplayFSMManager = this
        };

        tutorialState = new TutorialState()
        {
            gameplayFSMManager = this
        };

        pauseState = new PauseState()
        {
            gameplayFSMManager = this
        };

        stateTransition = new StateTransition()
        {
            gameplayFSMManager = this
        };

        //push the first state for the player
        PushState(tutorialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateStack.Peek().OnStateUpdate();
    }
    /// <summary>
    /// functions to define the stak functionality
    /// </summary>
    public void PopState()
    {
        if (stateStack.Count > 0)
            stateStack.Pop().OnStateExit();
    }
    public void PushState(IGameplayState newState)
    {
        newState.OnStateEnter();
        stateStack.Push(newState);

        if (currentStateTxt)
            currentStateTxt.text = stateStack.Peek().ToString();
    }

    /// <summary>
    /// Transion mapping function that maps to the transition between to states.
    /// Eg.
    /// Change from state 1 to state 2;
    /// --->> the function will detect that the transition state is FromState1ToState2
    /// <Look> Look at StateTransitionDirection summary </Look>
    /// </summary>
    /// <param name="nextState">
    /// a parameter to for the next state which will the gameplay move toward it
    /// </param>
    public void DetermineStateTransationDirection(IGameplayState nextState)
    {
        switch (stateStack.Peek().GetState())
        {
            case GameplayState.Tutorial:
                switch (nextState.GetState())
                {
                    case GameplayState.Tutorial:
                        //Error You are mapping to the same sate
                        break;
                    case GameplayState.AssemblyDisassembly:
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        break;
                    case GameplayState.Shooting:
                        break;
                    case GameplayState.Testing:
                        break;
                    case GameplayState.Transition:
                        break;
                    case GameplayState.Pause:
                        break;
                }
                break;
            case GameplayState.AssemblyDisassembly:
                switch (nextState.GetState())
                {
                    case GameplayState.Tutorial:
                        break;
                    case GameplayState.AssemblyDisassembly:
                        //Error You are mapping to the same sate
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        break;
                    case GameplayState.Shooting:
                        break;
                    case GameplayState.Testing:
                        break;
                    case GameplayState.Pause:
                        break;
                }
                break;
            case GameplayState.AssemblyDisassemblyTutorial:
                switch (nextState.GetState())
                {
                    case GameplayState.Tutorial:
                        break;
                    case GameplayState.AssemblyDisassembly:
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        //Error You are mapping to the same sate
                        break;
                    case GameplayState.Shooting:
                        break;
                    case GameplayState.Testing:
                        break;
                    case GameplayState.Pause:
                        break;
                }
                break;
            case GameplayState.Shooting:
                switch (nextState.GetState())
                {
                    case GameplayState.Tutorial:
                        break;
                    case GameplayState.AssemblyDisassembly:
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        break;
                    case GameplayState.Shooting:
                        //Error You are mapping to the same sate
                        break;
                    case GameplayState.Testing:
                        break;
                    case GameplayState.Pause:
                        break;
                }
                break;
            case GameplayState.Testing:
                switch (nextState.GetState())
                {
                    case GameplayState.Tutorial:
                        break;
                    case GameplayState.AssemblyDisassembly:
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        break;
                    case GameplayState.Shooting:
                        break;
                    case GameplayState.Testing:
                        //Error You are mapping to the same sate
                        break;
                    case GameplayState.Pause:
                        break;
                }
                break;
            case GameplayState.Pause:
                switch (nextState.GetState())
                {
                    case GameplayState.Tutorial:
                        break;
                    case GameplayState.AssemblyDisassembly:
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        break;
                    case GameplayState.Shooting:
                        break;
                    case GameplayState.Testing:
                        break;
                    case GameplayState.Pause:
                        //Error You are mapping to the same sate
                        break;
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// functions to defining how changing the gameplay state
    /// </summary>
    public void toTutorial()
    {
        DetermineStateTransationDirection(tutorialState);
        PopState();
        PushState(stateTransition);
    }
    public void toSooting() {

        DetermineStateTransationDirection(shootingState);
        PopState();
        PushState(stateTransition);
    }
    public void toTesting()
    {
        DetermineStateTransationDirection(testingState);
        PopState();
        PushState(stateTransition);
    }
    public void toAssemblyDisassembly()
    {
        DetermineStateTransationDirection(assemblyDissassemblyState);
        PopState();
        PushState(stateTransition);
    }
    public void toAssemblyDisassemblyTutorial()
    {
        DetermineStateTransationDirection(assemblyDisAssemblyTutorialState);
        PopState();
        PushState(stateTransition);
    }

    public void pauseGame()
    {
        if (tempFromPause == null)
        {
            tempFromPause = stateStack.Peek();
            PopState();
            PushState(pauseState);
        }

    }
    public void resumeGame()
    {
        if (tempFromPause != null)
        {
            PopState();
            PushState(tempFromPause);
            tempFromPause = null;
        }
    }

    //return the current state at the stack
    public GameplayState getCurrentState()
    {
        return stateStack.Peek().GetState();
    }

}
