using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LastEvent : MonoBehaviour {


    public GameObject doctor1;
    public GameObject doctor2;
    public GameObject camera;

    public GameObject player;
    public EventHandler eh;

    bool shakeStart;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    IEnumerator ShakeController()
    {
        shakeStart = true;
        yield return new WaitForSeconds(1f);
        shakeStart = false;
    }

    // Update is called once per frame
    void Update () {
        if (shakeStart)
        {
            SteamVR_Controller.Input((int)eh.index_droit.index).TriggerHapticPulse(1000);
            SteamVR_Controller.Input((int)eh.index_gauche.index).TriggerHapticPulse(1000);
        }
    }


    public void StartEvent()
    {
        StartCoroutine(ShakeController());

        camera.GetComponent<FadeScreen>().FadeOutVR(3);

        doctor1.GetComponent<Animator>().SetBool("walk", true);
        doctor2.GetComponent<Animator>().SetBool("walk", true);

        Vector3 destination = new Vector3(camera.transform.position.x,player.transform.position.y, camera.transform.position.z);


        doctor1.GetComponent<NavMeshAgent>().SetDestination(destination);
        doctor2.GetComponent<NavMeshAgent>().SetDestination(destination);
    }
}
