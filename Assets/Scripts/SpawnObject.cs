using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnObject; 

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hit a plane, spawn the object.
                foreach (ARRaycastHit hit in hits){
                    Pose hitPose = hit.pose;

                    Instantiate(spawnObject, hitPose.position, hitPose.rotation);



                }

                
            }
        }
    }
}