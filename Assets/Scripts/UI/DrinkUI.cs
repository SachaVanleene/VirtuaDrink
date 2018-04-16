using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkUI : MonoBehaviour {

    public GameObject text;

    public string drinkType;

    public Camera m_Camera;

	// Use this for initialization
	void Start () {
        text.GetComponent<Text>().text = drinkType;
	}
	
	// Update is called once per frame
	void Update () {
      transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
      m_Camera.transform.rotation * Vector3.up);
    }
}
