using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingWithUI : MonoBehaviour
{
    public GameObject controller;
    public Text tt;
 public void ZButtonClickedTest()
    {
        tt.text =""+ controller.transform.rotation;
    }
}
