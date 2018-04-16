using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateDecelerate : MonoBehaviour {


    bool forward;

    public GameObject rear_go;

    RearWheelDrive script_rear;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        script_rear = rear_go.GetComponent<RearWheelDrive>();
    }
    // Use this for initialization
    void Start () {
        if (gameObject.name == "Controller (right)")
        {
            forward = true;
        }
        if (gameObject.name == "Controller (left)")
        {
            forward = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (forward)
            {
                script_rear.accelerate = true;

            }
            else
            {
                script_rear.decelerate = true;
            }
        }
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (forward)
            {
                script_rear.accelerate = false;

            }
            else
            {
                script_rear.decelerate = false;
            }
        }
    }
}
