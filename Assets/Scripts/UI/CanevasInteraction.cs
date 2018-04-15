using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanevasInteraction : MonoBehaviour {

    Image image;
    Color inititalcolor;

    public bool hit;

    private void Awake()
    {
        image = GetComponent<Image>();
        inititalcolor = image.color;
        hit = false;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hit)
        {
            image.color = Color.blue;
        }
        else
        {
            image.color = inititalcolor;
        }
	}
}
