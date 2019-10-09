using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAssist : MonoBehaviour
{
    bool isSceneJustLoaded;
    int framCounter;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.updaeGameITemComponent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSceneJustLoaded)
        {
            framCounter++;
        }

        if (framCounter >= 10)
        {
            GameManager.Instance.updaeGameITemComponent();
            isSceneJustLoaded = false;
            framCounter = 0;
        }
    }
}
