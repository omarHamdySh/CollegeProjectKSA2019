using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesNames {
    MainUI,
    VRTutorial,
    Shooter,
    Assembly
}

[System.Serializable]
public class SceneMap {
    [SerializeField]
    public ScenesNames sceneIndex;
}
public class SceneMapping : MonoBehaviour
{
    [SerializeField]
    List<SceneMap> scenesMaps = new List<SceneMap>();

}
