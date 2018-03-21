using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretcherEvent : MonoBehaviour   {

    public GameObject boy;

    AudioSource pain;
    Animator anim;


    private void Awake()
    {
        pain = boy.GetComponent<AudioSource>();
        anim = boy.GetComponent<Animator>();
    }

    public void StartEvent()
    {
        pain.Play();
        StartCoroutine(CryThenDie());
    }

    IEnumerator CryThenDie()
    {
        yield return new WaitForSeconds(pain.clip.length);
        anim.SetTrigger("dead");
    }

}
