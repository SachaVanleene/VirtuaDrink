using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventStats : MonoBehaviour {

    //GLobal Stats
    public bool hasBeenPlayed;
    public int lockingTime;
    public int personality;
    public GameObject UI_Go;
    PersonnalityManager pm;
    GameObject gm;
    EventHandler eh;
    //
    public int eventNum;


    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        eh = gm.GetComponent<EventHandler>();
        pm = UI_Go.GetComponent<PersonnalityManager>();
        pm.button.GetComponent<Button>().onClick.AddListener(delegate { CloseEvent(); });
    }


    public void LaunchEvent()
    {
        hasBeenPlayed = true;
        eh.LockPlayer();
        if(eventNum == 1)
        {
            GetComponent<StretcherEvent>().StartEvent();
        }
        if(eventNum == 2)
        {
            GetComponent<StudentsEvent>().StartEvent();
        }
        if(eventNum == 3)
        {
            GetComponent<LastEvent>().StartEvent();
        }
        StartCoroutine(WaitForEventToPlay());
    }

    IEnumerator WaitForEventToPlay()
    {
        yield return new WaitForSeconds(lockingTime);
        pm.FichePerso(personality);
        pm.panel.SetActive(true);
        eh.Pause();
    }

    public void CloseEvent()
    {
        pm.panel.SetActive(false);
        eh.UnlockPlayer();
        eh.Unpause();
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
