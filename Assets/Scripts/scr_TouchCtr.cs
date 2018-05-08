﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TouchCtr : MonoBehaviour {

    public OVRInput.Controller MyController;
    public Animator AnimatorHand;
    GameObject Hand;

    [HideInInspector]
    public GameObject ObjectGrab;

    [HideInInspector]
    public GameObject PosibleObjectGrab;

    public GameObject Player;

    OVRInput.Axis1D GrabButton;

    bool IsRight = true;

    scr_HandsControl HandsParent;

	// Use this for initialization
	void Start () {
        ObjectGrab = null;
        PosibleObjectGrab = null;
        HandsParent = transform.parent.GetComponent<scr_HandsControl>();

        Hand = AnimatorHand.gameObject;
        if (MyController == OVRInput.Controller.RTouch)
        {
            IsRight = true;
            GrabButton = OVRInput.Axis1D.SecondaryHandTrigger;
        } else
        {
            IsRight = false;
            GrabButton = OVRInput.Axis1D.PrimaryHandTrigger;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!OVRInput.GetControllerPositionTracked(MyController))
            Debug.Log("No traking");
        
        Quaternion HandQ = OVRInput.GetLocalControllerRotation(MyController);

        transform.localPosition = OVRInput.GetLocalControllerPosition(MyController)+new Vector3(0f,0.6f,0f);
        transform.rotation =  Quaternion.Euler(HandQ.eulerAngles.x, HandQ.eulerAngles.y +HandsParent.plusRot, HandQ.eulerAngles.z);

        if (OVRInput.Get(GrabButton)>0.5)
        {
            AnimatorHand.SetBool("Grab",true);
            if (PosibleObjectGrab && !ObjectGrab)
            {
                ObjectGrab = PosibleObjectGrab;
                ObjectGrab.transform.position = Vector3.zero;
                ObjectGrab.transform.rotation = Quaternion.identity;
                ObjectGrab.GetComponent<Rigidbody>().useGravity = false;
                ObjectGrab.transform.SetParent(Hand.transform);
                if (ObjectGrab.GetComponent<SphereCollider>())
                    ObjectGrab.GetComponent<SphereCollider>().enabled = false;
                if (ObjectGrab.GetComponent<BoxCollider>())
                    ObjectGrab.GetComponent<BoxCollider>().enabled = false;
            }
        } else
        {
            AnimatorHand.SetBool("Grab", false);
            if (ObjectGrab)
            {
                ObjectGrab.GetComponent<Rigidbody>().useGravity = true;
                ObjectGrab.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(MyController);
                ObjectGrab.transform.parent = null;
                if (ObjectGrab.GetComponent<SphereCollider>())
                    ObjectGrab.GetComponent<SphereCollider>().enabled = true;
                if (ObjectGrab.GetComponent<BoxCollider>())
                    ObjectGrab.GetComponent<BoxCollider>().enabled = true;
                ObjectGrab = null;
            }
        }

        if (ObjectGrab)
        {
            ObjectGrab.transform.position = Hand.transform.position;
            ObjectGrab.transform.rotation = Hand.transform.rotation;
        }

        if (!PosibleObjectGrab)
            AnimatorHand.SetBool("Interact", false);
        else
            AnimatorHand.SetBool("Interact", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanGrab") && !ObjectGrab && !PosibleObjectGrab)
        {
            PosibleObjectGrab = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CanGrab") && PosibleObjectGrab==other.gameObject)
        {
            PosibleObjectGrab = null;
        }
    }
}
