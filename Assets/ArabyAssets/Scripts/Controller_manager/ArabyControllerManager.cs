using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//15 Mode 
public enum ControllerModes
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
public class ArabyControllerManager : MonoBehaviour
{
    private static  ArabyControllerManager _Instance;
    public static ArabyControllerManager Instance
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
    // Start is called before the first frame update
    void Start()
    {
                                                                                                                                                                                                                     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
