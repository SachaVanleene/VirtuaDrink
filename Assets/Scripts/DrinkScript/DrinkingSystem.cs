using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingSystem : MonoBehaviour {

    RaycastHit hit;
    public LayerMask mask;


    public GameObject drink_manager;
    DrinkingManager script_dm;


    float ingerationSpeed;
    public string type;

    public int controller_used;

    private void Awake()
    {
        ingerationSpeed = 0.001f;
        script_dm = drink_manager.GetComponent<DrinkingManager>();
    }

    // Use this for initialization
    void Start () {
		
	}


    // Update is called once per frame
    void Update () {
        Debug.DrawRay(transform.position, transform.up * hit.distance, Color.yellow);
        if (Physics.Raycast(transform.position, transform.up, out hit, 100,mask))
        {
            //Debug.LogError("Drink "+type);
            SteamVR_Controller.Input(controller_used).TriggerHapticPulse(1000);
            switch (type)
            {
                case "Biere":
                    script_dm.AddAlcohol(ingerationSpeed*5);
                    break;
                case "Vodka":
                    script_dm.AddAlcohol(ingerationSpeed * 45);
                    break;
                case "Rhum":
                    script_dm.AddAlcohol(ingerationSpeed * 35);
                    break;
                case "Vin":
                    script_dm.AddAlcohol(ingerationSpeed * 12);
                    break;
                default:
                    break;
            }
        }
    }
}
