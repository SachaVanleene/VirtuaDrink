using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    // 1
    public GameObject laserPrefab;
    // 2
    private GameObject laser;
    // 3
    private Transform laserTransform;
    // 4
    private Vector3 hitPoint;

    //Teleport
    // 1
    public Transform cameraRigTransform;
    // 2
    public GameObject teleportReticlePrefab;
    // 3
    private GameObject reticle;
    // 4
    private Transform teleportReticleTransform;
    // 5
    public Transform headTransform;
    // 6
    public Vector3 teleportReticleOffset;
    // 7
    public LayerMask teleportMask;
    // 8
    private bool shouldTeleport;

    public bool canTeleport;

    private bool close;

    private GameObject go_button;

    private GameObject previous_champ;

    Vector3 previous_position;

    private int nb_iter_smooth;


    //UI Handle
    public LayerMask uiMask;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        canTeleport = true;

        previous_champ = null;

        nb_iter_smooth = 0;

        close = false;
    }

    // Use this for initialization
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

        // 1
        reticle = Instantiate(teleportReticlePrefab);
        // 2
        teleportReticleTransform = reticle.transform;
    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }

    private void Teleport()
    {
        // 1
        shouldTeleport = false;
        // 2
        reticle.SetActive(false);
        // 3
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        // 4
        difference.y = 1;
        // 5
        cameraRigTransform.position = hitPoint + difference;

        //cameraRigTransform.transform.position = new Vector3(cameraRigTransform.position.x, 0f, cameraRigTransform.position.z);
        
    }


	
	// Update is called once per frame
	void Update () {
        if (canTeleport)
        {
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                RaycastHit hit;
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("TeleportMask")) //obligé de faire ça car le prefab de la route est un tout du coup on peut se tp partout ...
                    {
                        hitPoint = hit.point;
                        ShowLaser(hit);
                        // 1
                        reticle.SetActive(true);
                        // 2
                        teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                        // 3
                        shouldTeleport = true;
                    } else
                    {
                        hitPoint = hit.point;
                        ShowLaser(hit);
                        reticle.SetActive(false);
                        shouldTeleport = false;
                        
                    }
                }
            }
            else // 3
            {
                laser.SetActive(false);
                reticle.SetActive(false);
            }

            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport)
            {
                Teleport();
            }

        }

        if (!canTeleport)
        {
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                close = false;
                RaycastHit hit;
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))

                hitPoint = hit.point;
                ShowLaser(hit);
                if(hit.transform.gameObject != null)
                {
                    if (hit.transform.gameObject.tag == "CloseButton")
                    {
                        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
                        close = true;
                        go_button = hit.transform.gameObject;
                        if (Controller.GetHairTriggerDown())
                        {
                            hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                        }
                        if (previous_champ != null)
                        {
                            previous_champ.GetComponent<CanevasInteraction>().hit = false;
                            previous_champ.transform.localPosition = previous_position;
                        }
                    }
                    if (hit.transform.gameObject.tag == "Champ")
                    {
                        HandleChampHitByRay(hit.transform.gameObject);
                    }
                }

            }
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.SetActive(false);
                if (close)
                {
                    go_button.GetComponent<Button>().onClick.Invoke();
                    close = false;
                }
            }
        }
    }

    void HandleChampHitByRay(GameObject go)
    {
        if (previous_champ != null)
        {
            if (!GameObject.ReferenceEquals(previous_champ, go))
            {
                                        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);

                previous_champ.GetComponent<CanevasInteraction>().hit = false;
                previous_champ.transform.localPosition = previous_position;

                go.GetComponent<CanevasInteraction>().hit = true;
                previous_position = go.transform.localPosition;
                previous_champ = go;
                nb_iter_smooth = 0;
                StartSmooth(go);
            }
        } else
        {
            go.GetComponent<CanevasInteraction>().hit = true;
            previous_position = go.transform.localPosition;
            previous_champ = go;
            nb_iter_smooth = 0;
            StartSmooth(go);
        }

    }

    void StartSmooth(GameObject go)
    {
        if (nb_iter_smooth < 10)
        {
            //StartCoroutine(Smooth(go));
            Smooth(go);
        }
    }

    void Smooth(GameObject go)
    {
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, go.transform.localPosition.z - 4f);
        //go.transform.localPosition = go.transform.localPosition - 4f * go.transform.forward;
        nb_iter_smooth += 1;
        StartSmooth(go);
    }

    IEnumerator Smooth2(GameObject go)
    {
        yield return new WaitForSeconds(0.1f);
        go.transform.localPosition = go.transform.localPosition - 1f * go.transform.forward;
        nb_iter_smooth += 1;
        StartSmooth(go);
    }

}
