using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AccidentDetector : MonoBehaviour
{
	public GameObject accidentText;
    public GameObject m_camera;
    FadeScreen script_fade;

    private void Awake()
    {
        script_fade = m_camera.GetComponent<FadeScreen>();
    }

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
        script_fade.FadeOutVR("Scene/Post Accident");
	}
}
