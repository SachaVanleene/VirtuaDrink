using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LastEvent : MonoBehaviour {


    public GameObject doctor1;
    public GameObject doctor2;
    GameObject player;
    public GameObject camera;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartEvent()
    {
        camera.GetComponent<FadeScreen>().FadeOut();

        doctor1.GetComponent<Animator>().SetBool("walk", true);
        doctor2.GetComponent<Animator>().SetBool("walk", true);

        doctor1.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        doctor2.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
}
