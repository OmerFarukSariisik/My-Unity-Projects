using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YCController : MonoBehaviour
{
    private const float Y_ANGLE_MİN = 0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public bool isLocked;
    public Camera ycCam;
    public Transform ycObj, ycCamObj;
    public float camDistance;

    private GameObject focusObj;
    private Vector3 lastPointerPos;

    private float currX = 0.001f, currY = 0.001f;
    private Focusable focus;

    RaycastHit hit;

    public void Look()
    {
        Vector3 dir = new Vector3(0, 0, -camDistance);
        Quaternion rot = Quaternion.Euler(currX, currY, 0);
        ycCamObj.position = ycObj.position + rot * dir;
        ycCamObj.LookAt(ycObj.position);
    }

    public void ClickFocusable()
    {
        focusObj.GetComponent<Focusable>().TriggerObj();
    }

    public void LockPlayer()
    {
        isLocked = true;
    }

    public void UnlockPlayer()
    {
        isLocked = false;
    }

    private void Update()
    {
        currY += Input.GetAxis("Mouse X");
        currX += Input.GetAxis("Mouse Y");

        currX = Mathf.Clamp(currX, Y_ANGLE_MİN, Y_ANGLE_MAX);

        //** DÜZELTİLECEK SADECE SON SAHNE
        print("ozan burayı düzelt");
        currY = Mathf.Clamp(currY, -50, 50);

        if (!isLocked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = ycCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    if(hit.transform.tag == "Focusable")
                    {
                        Focusable obj = hit.transform.gameObject.GetComponent<Focusable>();
                        obj.TriggerObj();
                    }
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (!isLocked)
        {
            Ray ray = ycCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (hit.transform.tag == "Focusable")
                {
                    focus = hit.transform.gameObject.GetComponent<Focusable>();
                    if (Input.GetMouseButtonDown(0))
                    {
                        focus.TriggerObj();
                    }
                    else if(!focus.isFocused)
                    {
                        focus.FocusEnter();
                    }
                }
            }else if( focus != null)
            {
                focus.FocusExit();
                focus = null;
            }

            
        }
    }

    private void LateUpdate()
    {
        Look();
    }

}
