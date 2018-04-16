using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRespawn : MonoBehaviour {

    Vector3 initial_position;
    Quaternion initial_rotation;

	// Use this for initialization
	void Start () {
        initial_position = this.transform.position;
        initial_rotation = this.transform.rotation;
	}
	
    public void Respawn()
    {
        StartCoroutine(StartRespawn());
    }

    IEnumerator StartRespawn()
    {
        yield return new WaitForSeconds(5f);
        this.transform.rotation = initial_rotation;
        this.transform.position = initial_position;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
