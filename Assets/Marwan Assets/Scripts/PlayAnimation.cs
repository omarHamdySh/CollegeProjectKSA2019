using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animator anim;
    bool isplay = true;
    public GameObject showInforamtionObject;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Play_Animator_Assembly()
    {
        if (isplay)
        {
            showInforamtionObject.SetActive(false);
            print("conditation if");
            anim.enabled = true;
            anim.Play("Grenadeassembely");
            anim.SetTrigger("x");
        }
        else
        {
            anim.Play("TESTANIM");
            anim.enabled = true;
        }

        isplay = !isplay;
    }

    public void Play_Animator_Disassembly()
    {
        if (isplay)
        {
            print("conditation if");
            anim.enabled = true;
            anim.Play("Grenadedisassembely");
            anim.SetTrigger("x");
            StartCoroutine(ShowInformation());
        }
        else
        {
            anim.Play("TESTANIM");
            anim.enabled = true;
        }

        isplay = !isplay;
    }

    IEnumerator ShowInformation()
    {
        yield return new WaitForSeconds(7f);
        showInforamtionObject.SetActive(true);
    }

}
