using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private GameObject collidingObject;
    private GameObject objectInHand;

    public GameObject Manager;
    DrinkingManager script_dm;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        script_dm = Manager.GetComponent<DrinkingManager>();
    }

    private void SetCollidingObject(Collider col)
    {
        //Debug.LogError("COllision detecte");
        if (!col.GetComponent<Rigidbody>())
        {
            //Debug.LogError("No Rigid Body");
        }
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        //Debug.LogError("J'entre");
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
       // Debug.LogError("Je sors");
        collidingObject = null;
    }

    private void GrabObject()
    {
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(1000);
        //Debug.LogError("Grab");
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        if (objectInHand.transform.Find("Canvas"))
        {
            GameObject canevas = objectInHand.transform.Find("Canvas").gameObject;
            canevas.SetActive(false);
        }
        if (objectInHand.transform.Find("Bottom"))
        {
            GameObject bottom = objectInHand.transform.Find("Bottom").gameObject;
            bottom.GetComponent<DrinkingSystem>().controller_used = (int)trackedObj.index;
        }
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        if (objectInHand.GetComponent<DrinkRespawn>())
        {
            objectInHand.GetComponent<DrinkRespawn>().Respawn();
        }
        if (objectInHand.transform.Find("Canvas"))
        {
            GameObject canevas = objectInHand.transform.Find("Canvas").gameObject;
            canevas.SetActive(true);
        }
        // 4
        objectInHand = null;
    }

    // Update is called once per frame
    void Update () {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
            if (gameObject.name == "Controller (right)")
            {
                //Debug.LogError("je passe right");
                script_dm.gachette_right_pressed = true;
                script_dm.right_controller_index = (int)trackedObj.index;
            }
            if (gameObject.name == "Controller (left)")
            {
                //Debug.LogError("je passe left");
                script_dm.gachette_left_pressed = true;
                script_dm.left_controller_inderx = (int)trackedObj.index;
            }
        }
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
            if (gameObject.name == "Controller (right)")
            {
                script_dm.gachette_right_pressed = false;
            }
            if (gameObject.name == "Controller (left)")
            {
                script_dm.gachette_left_pressed = false;
            }
        }
    }
}
