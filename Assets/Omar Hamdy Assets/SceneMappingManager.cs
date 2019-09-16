using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public ScenesNames sceneName;

    /// <summary>
    /// This Method is made to be used from inside the code not from the inspector since it doesn't take a primitive datatype
    /// as a paramter, instead it takes enum which will make the method unable to appear at any unity event in inspector.
    /// </summary>
    /// <param name="sceneName"> It is an enum SceneNames </param>
    public void changeScene(ScenesNames sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    /// <summary>
    /// This method will be invoked at unity event after adding this script to the game object in 
    /// inspector and choosing the scene will be changed to.
    /// </summary>
    public void changeScene()
    {
        SceneManager.LoadScene(this.sceneName.ToString());
    }



    /**
     *Further Edits Expectations:
     *  - Adding asynchronous scene changning mehtod;
     *  - Adding another relative mechanisms.
     **/
}
