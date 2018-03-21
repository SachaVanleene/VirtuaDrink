using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLauncher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogError("Collide");
        if(other.gameObject.layer == 8)
        {
            EventStats es_script = other.gameObject.GetComponent<EventStats>();
            if (!es_script.hasBeenPlayed)
            {
                es_script.LaunchEvent();
            }
        }
    }
}
