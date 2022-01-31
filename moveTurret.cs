using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTurret : MonoBehaviour
{
    
    RaycastHit hit;
    private Vector3 currentpos;
    private Touch touch;

    void Start()
    {
        touch = Input.GetTouch(0);
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
                transform.position = hit.point;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
                transform.position = hit.point;
            }
        }
        
    }
}
