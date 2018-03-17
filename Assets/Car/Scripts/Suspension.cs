using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour {

	public Rigidbody rb;
	public Car truckScript;

	[Header("Suspension settings")]
	public float springForce;
	public float damperForce;
	public float springConstant;
	public float damperConstant;
	public float restLenght;

	private float previouseLenght;
	private float currentLenght;
	private float springVelocity;


	// Use this for initialization
	void Awake() {
		truckScript = transform.parent.GetComponent<Car> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;

		// I think i should modifiy below line to be like : out hit;
		if(Physics.Raycast(transform.position, -transform.up, out hit, restLenght + truckScript.wheelRadius)){
			previouseLenght = currentLenght;
			currentLenght   = restLenght - (hit.distance - truckScript.wheelRadius);
			springVelocity  = (currentLenght - previouseLenght) / Time.fixedDeltaTime;
			springForce 	= springConstant * currentLenght;
			damperForce 	= damperConstant * springVelocity;

			// let's add the force to the car 
			rb.AddForceAtPosition(transform.up * (springForce + damperForce), transform.position);
		}
	}
}