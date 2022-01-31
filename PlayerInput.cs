using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;


public class PlayerInput : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector2 panLimit;
    public float minzoom = 35f;
    public float maxzoom = 75f;
    public float bottom_x;
    public float bottom_z;

    private Vector3 cam_pos;

    //private GameObject _turret;

    //Buildmanager buildmanager;

    //Toggle turret_toggle;

    // Start is called before the first frame update
    void Start()
    {
        cam_pos = transform.position;
        //buildmanager = Buildmanager.instance;
        //turret_toggle = GetComponent<Toggle>();
        //turret_toggle.onValueChanged.AddListener(delegate {ToggleValueChanged(turret_toggle); });
    }

    // Update is called once per frame
    void Update()
    {

        //maybe add a state change, where this is code is inactive when the button is pressed or the turret isnt placed

       if (Input.touchCount > 0) //if more than one finger is on screen and the finger is moving across screen
        {
            Touch touch = Input.GetTouch(0);
            //Touch touchtwo = Input.GetTouch(1);

            if (Input.touchCount == 2)
            {
                Touch touchtwo = Input.GetTouch(1);
                Vector2 touchZeroPrevPos = touch.position - touch.deltaPosition;
                Vector2 touchTwoPrevPos = touchtwo.position - touchtwo.deltaPosition;

                float prevMag = (touchZeroPrevPos - touchTwoPrevPos).magnitude;
                float currentMag = (touch.position - touchtwo.position).magnitude;
                float diff = currentMag - prevMag;

                Zoom(diff * 0.02f);
            }
            
            else if (Input.touchCount == 1 && touch.phase == TouchPhase.Moved)
            {

                //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
                
                Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
                transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0, Space.Self);
                cam_pos.x = Mathf.Clamp (transform.position.x, bottom_x, panLimit.x);
                cam_pos.z = Mathf.Clamp (transform.position.z, bottom_z, panLimit.y);
                transform.position = cam_pos;
                        
            }
            /*
            if (touch.phase == TouchPhase.Moved && turret_toggle)
            {
                MoveObjectToTouch();
            }
            */
        }

    }

    /*
    private void MoveObjectToTouch()
    {
        if (turret_toggle.enabled)
            {
                if (_turret == null)
                {
                    BuildTurret();
                }
                
                Ray ray = Camera.main.ScreenPointToRay(Input.touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    _turret.transform.position = hit.point;

                }
            }
    }
    */


    public void BuildTurret()
    {
        
        
        //_turret = (GameObject)Instantiate(buildmanager.getTurretToBuild);
    }

    void Zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, minzoom, maxzoom);
    }


}
