using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretcherEvent : MonoBehaviour   {

    public GameObject boy;

    AudioSource pain;
    Animator anim;

    public EventHandler eh;

    bool shakeControllers;

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
        shakeControllers = true;
        yield return new WaitForSeconds(pain.clip.length);
        shakeControllers = false;
        anim.SetTrigger("dead");
    }

    private void Update()
    {
        if (shakeControllers)
        {
            SteamVR_Controller.Input((int)eh.index_droit.index).TriggerHapticPulse(3000);
            SteamVR_Controller.Input((int)eh.index_gauche.index).TriggerHapticPulse(3000);
        }
    }

}
