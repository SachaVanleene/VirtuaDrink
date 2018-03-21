using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour {


    public bool canTeleport;
    int pos;
    public GameObject[] TeleportPoint;
	// Use this for initialization
	void Start () {
        canTeleport = true;
        pos = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (pos < TeleportPoint.Length - 1)
                {
                    pos = pos + 1;
                    this.transform.position = TeleportPoint[pos].transform.position;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (pos > 0)
                {
                    pos = pos - 1;
                    this.transform.position = TeleportPoint[pos].transform.position;
                }
            }
        }
	}

}
