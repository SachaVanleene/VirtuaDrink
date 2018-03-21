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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        Time.timeScale = 0;
        movement.speed = 0f;
        mouse_x.enabled = false;
        mouse_y.enabled = false;
        AudioListener.pause = true;
        pt.canTeleport = false;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        movement.speed = initSpeed;
        mouse_x.enabled = true;
        mouse_y.enabled = true;
        AudioListener.pause = false;
        pt.canTeleport = true;
    }

    public void LockPlayer()
    {
        pt.canTeleport = false;
        mouse_x.enabled = false;
        movement.speed = 0f;
    }

    public void UnlockPlayer()
    {
        pt.canTeleport = true;
        mouse_x.enabled = true;
        movement.speed = initSpeed;
    }
}
