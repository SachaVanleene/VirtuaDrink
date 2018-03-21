using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimStart : MonoBehaviour {

    Animator anim;
    float animTime;
    [Range(0f, 1f)] public float startTime;
    [Range(0f, 100f)] public float speed;


    // Use this for initialization
    void Start () {
        animTime = 8.333f;
        anim = GetComponent<Animator>();
        StartCoroutine(WaitBeforeLaunchAnim());
	}
	
    IEnumerator WaitBeforeLaunchAnim()
    {
        yield return new WaitForSeconds(startTime*animTime);
        anim.SetTrigger("start");
    }

    public void IncreaseSpeed()
    {
        anim.speed = speed;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
