using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    GameObject player;
    CameraFPS mouse_x;
    PlayerMovement movement;
    PlayerTeleport pt;
    float initSpeed;
    GameObject camera;
    CameraFPS mouse_y;
    AudioListener al;

    // Vive material reference
    public GameObject manette1;
    public GameObject manette2;
    public SteamVR_TrackedObject index_droit;
    public SteamVR_TrackedObject index_gauche;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        mouse_x = player.GetComponent<CameraFPS>();
        mouse_y = camera.GetComponent<CameraFPS>();
        al = camera.GetComponent<AudioListener>();
        movement = player.GetComponent<PlayerMovement>();
        initSpeed = movement.speed;
        pt = player.GetComponent<PlayerTeleport>();

        index_droit = manette1.GetComponent<SteamVR_TrackedObject>();
        index_gauche = manette2.GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        Time.timeScale = 0;
        /*movement.speed = 0f;
        mouse_x.enabled = false;
        mouse_y.enabled = false;*/

    }

    public void Unpause()
    {
        Time.timeScale = 1;
        /*movement.speed = initSpeed;
        mouse_x.enabled = true;
        mouse_y.enabled = true;*/
        AudioListener.pause = false;
    }

    public void LockPlayer()
    {

        manette1.GetComponent<LaserPointer>().canTeleport = false;
        manette2.GetComponent<LaserPointer>().canTeleport = false;

       /* pt.canTeleport = false;
        mouse_x.enabled = false;
        movement.speed = 0f;*/
    }

    public void UnlockPlayer()
    {

        manette1.GetComponent<LaserPointer>().canTeleport = true;
        manette2.GetComponent<LaserPointer>().canTeleport = true;

        /*pt.canTeleport = true;
        mouse_x.enabled = true;
        movement.speed = initSpeed;*/
    }
}
