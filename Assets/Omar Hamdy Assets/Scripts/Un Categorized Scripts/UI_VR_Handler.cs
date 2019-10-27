 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

public class UI_VR_Handler : MonoBehaviour
{
    private VRTK_InteractableObject Vrscript;
    public UnityEvent onSelect;
    public float highlightTimeThreshold = 3;
    float seconds;
    public GameObject HighlightGameObject;

    // Start is called before the first frame update
    void Start()
    {
        Vrscript = GetComponent<VRTK_InteractableObject>();
        HighlightGameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        countSeconds();
        CheckForSelectionThreshold();
    }

    public void countSeconds()
    {

        if (Vrscript.enabled)
        {
            seconds += Time.deltaTime;
        }
    }
    private void CheckForSelectionThreshold()
    {
        if ((Vrscript.enabled && (seconds >= highlightTimeThreshold)))
        {
            seconds = 0;
            onSelect.Invoke();
        }
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

