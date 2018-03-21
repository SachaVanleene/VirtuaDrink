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
			UponAccident();
	}

	private void OnTriggerEnter(Collider other)
	{
		UponAccident();
	}

	private void UponAccident()
	{
		accidentText.SetActive(true);
		GetComponent<FadeScreen>().FadeIn();
	}
}
