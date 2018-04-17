using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RappelQuantiteBilan : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "Vous aviez ingéré " + AlcoolQuantity.alcool_quantity.ToString(".0##") + " g/cl";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
