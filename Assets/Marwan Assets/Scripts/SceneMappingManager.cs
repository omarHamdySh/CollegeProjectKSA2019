using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesNames
{
    Home,
    Shooter,
    Assembly
}

[System.Serializable]
public class SceneMap
{
    [SerializeField]
    public ScenesNames sceneIndex;
}
public class SceneMappingManager : MonoBehaviour
{
    private static SceneMappingManager _Instance;

    public static SceneMappingManager Instance                             //Getter Method.
    {
        get { return _Instance; }
    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void changeScene(ScenesNames sceneName)
    {

        SceneManager.LoadScene(sceneName.ToString());
    }
}
