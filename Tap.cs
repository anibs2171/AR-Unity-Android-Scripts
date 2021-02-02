using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class Tap : MonoBehaviour
{

    public GameObject arcam;

    public GameObject testinstantiate;
   
    //private GameObject testspawned;

    private ARRaycastManager arRaycm;
    private Vector2 touchpos;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    // Start is called before the first frame update
    private void Awake()
    {
        arRaycm = GetComponent<ARRaycastManager>();
    }

    bool IfTouched(out Vector2 touchpos)
    {
        if (Input.touchCount > 0)
        {
            touchpos = Input.GetTouch(index: 0).position;
            return true;
        }
        touchpos = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!IfTouched(out Vector2 touchpos))
            return;
        if (arRaycm.Raycast(touchpos, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;
            float yRotation = arcam.transform.eulerAngles.y;
            
            testinstantiate.transform.eulerAngles = new Vector3(testinstantiate.transform.eulerAngles.x, yRotation+200, testinstantiate.transform.eulerAngles.z);

            testinstantiate.transform.position = hitPos.position;
        }




    }
}