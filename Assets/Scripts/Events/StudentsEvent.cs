﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentsEvent : MonoBehaviour {

    AudioSource cry;
    public GameObject leftMan;
    public GameObject woman;
    public GameObject rightMan;
    public ParticleSystem flame;
    public GameObject car;
    public Light light;
    // Use this for initialization
    void Start () {
        cry = GetComponent<AudioSource>();
	}

    public void StartEvent()
    {
        PlaySond();
        StartCoroutine(WaitSoundToBePlay());
    }

    void PlaySond()
    {
        leftMan.GetComponent<AudioSource>().Play();
        woman.GetComponent<AudioSource>().Play();
        rightMan.GetComponent<AudioSource>().Play();
    }

    void StopWomanAndLaunchCrazySound()
    {
        woman.GetComponent<AudioSource>().Stop();
        cry.Play();
        StartCoroutine(WaitForCrazySound());
    }

    IEnumerator HandleFlame()
    {
        car.GetComponent<AudioSource>().Play();
        flame.startSpeed = 3f;
        light.intensity = 20;
        light.enabled = true;
        flame.Play();
        yield return new WaitForSeconds(1f);
        light.intensity = 10;
        flame.startSpeed = 1.5f;
        StopWomanAndLaunchCrazySound();
    }

    IEnumerator WaitForCrazySound()
    {
        yield return new WaitForSeconds(cry.clip.length/2);
        //MakeStudentTerrify();
    }
	
    IEnumerator WaitSoundToBePlay()
    {
        yield return new WaitForSeconds(8f);
        StartCoroutine(HandleFlame());
    }

    void MakeStudentTerrify()
    {
        leftMan.GetComponent<ChangeAnimStart>().IncreaseSpeed();
        woman.GetComponent<ChangeAnimStart>().IncreaseSpeed();
        rightMan.GetComponent<ChangeAnimStart>().IncreaseSpeed();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
