using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
	private Rigidbody rb;

	[Header("Car Specs")]
	public float wheelRadius;

	// Use this for initialization
	void Awake() {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
