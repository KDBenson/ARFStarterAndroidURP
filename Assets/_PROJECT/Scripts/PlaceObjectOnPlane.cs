using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    [SerializeField]
    GameObject m_ObjectToPlace;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //make sure only spawning 1 object per touch
            if (touch.phase == TouchPhase.Began)
            {
                if(m_RaycastManager.Raycast(touch.position, s_Hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    Instantiate(m_ObjectToPlace, hitPose.position, hitPose.rotation);
                }
            }

        }
        
    }
}
