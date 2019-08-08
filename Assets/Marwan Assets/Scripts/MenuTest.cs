using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTest : MonoBehaviour
{
    public GameObject menu;
    public int rotationTarget;
    // Update is called once per frame
    void Update()
    {
        if (this.transform.eulerAngles.z > rotationTarget)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
