using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabyTesting : MonoBehaviour
{
    public GameObject _FuckingTest;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeFuckingController()
    {
        Debug.LogError("Hello Befor");
        VRTK.VRTK_SDKManager.instance.scriptAliasRightController = _FuckingTest;
        Debug.LogError("Hello after");
    }
}
