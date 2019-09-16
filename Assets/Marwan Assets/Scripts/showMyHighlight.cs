using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMyHighlight : MonoBehaviour
{
    public GameObject HighlightGameObject;
    // Use this for initialization
    void Start()
    {
        HighlightGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnableHighlight()
    {
        HighlightGameObject.SetActive(true);

    }
    public void DisableHighlight()
    {

        HighlightGameObject.SetActive(false);
    }
}
