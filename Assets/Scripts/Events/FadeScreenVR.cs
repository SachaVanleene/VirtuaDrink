using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreenVR : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SteamVR_Fade.Start(Color.black,10f,true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
