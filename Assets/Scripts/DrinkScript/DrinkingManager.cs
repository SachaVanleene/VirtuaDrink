using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkingManager : MonoBehaviour {

    float alcohol;
    float time;

    bool sceneSwitched;

    GameObject ui_quantite;

    public GameObject m_camera;

    public bool gachette_right_pressed;
    public bool gachette_left_pressed;

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    private void Awake()
    {
        sceneSwitched = false;
        ui_quantite = getChildGameObject(this.gameObject, "AlcoolQuantity");
    }

    public void AddAlcohol(float quantity)
    {
        alcohol += quantity;
        UpdateText();
    }

    void UpdateText()
    {
        ui_quantite.GetComponent<Text>().text = alcohol.ToString(".0##") + " g/cl";
    }

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		if(gachette_left_pressed && gachette_left_pressed && !sceneSwitched)
        {
            SteamVR_Controller.Input(3).TriggerHapticPulse(500);
            SteamVR_Controller.Input(4).TriggerHapticPulse(500);
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
        }
        if (time >= 2f && !sceneSwitched)
        {
            AlcoolQuantity.alcool_quantity = alcohol;
            sceneSwitched = true;
            m_camera.GetComponent<FadeScreen>().FadeOutVR(1);
        }
	}
}
