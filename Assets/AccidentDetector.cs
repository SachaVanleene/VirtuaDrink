using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccidentDetector : MonoBehaviour
{
	public GameObject accidentText;
	
	private void FixedUpdate()
	{
		if (Vector3.Dot(transform.up, Vector3.down) > 0)
			accidentText.SetActive(true);
	}

	private void OnTriggerEnter(Collider other)
	{
		accidentText.SetActive(true);
	}
}
