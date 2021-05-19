﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PlaceOnPlane : MonoBehaviour
{
    private ARSessionOrigin sessionOrigin;
    private List<ARRaycastHit> hits;

    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        sessionOrigin = GetComponent<ARSessionOrigin>(); 
        hits = new List<ARRaycastHit>();
        model.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
            return;
        
        Touch touch = Input.GetTouch(0);

        if(sessionOrigin.Raycast(touch.position,hits,UnityEngine.Experimental.XR.TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            if(!model.activeInHierarchy)
            {
                model.SetActive(true);
                model.transform.position = pose.position;
                model.transform.rotation = pose.rotation;
            }
        }
        
    }
}
