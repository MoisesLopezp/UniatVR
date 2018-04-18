using System.Collections;
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

    bool IsRight = true;

	// Use this for initialization
	void Start () {
        ObjectGrab = null;
        PosibleObjectGrab = null;

        Hand = AnimatorHand.gameObject;
        if (MyController == OVRInput.Controller.RTouch)
        {
            IsRight = true;
        } else
        {
            IsRight = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!OVRInput.GetControllerPositionTracked(MyController))
        {
            Debug.Log("No traking");
        }

        transform.position = Player.transform.position+OVRInput.GetLocalControllerPosition(MyController)+new Vector3(0f,0.6f,0f);
        transform.rotation = OVRInput.GetLocalControllerRotation(MyController);

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, MyController)>0.5)
        {
            AnimatorHand.SetBool("Grab",true);
            if (PosibleObjectGrab && !ObjectGrab)
            {
                ObjectGrab = PosibleObjectGrab;
                ObjectGrab.transform.position = Vector3.zero;
                ObjectGrab.transform.rotation = Quaternion.identity;
                ObjectGrab.GetComponent<Rigidbody>().useGravity = false;
                ObjectGrab.transform.SetParent(Hand.transform);
            }
        } else
        {
            AnimatorHand.SetBool("Grab", false);
            if (ObjectGrab)
            {
                ObjectGrab.GetComponent<Rigidbody>().useGravity = true;
                ObjectGrab.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(MyController);
                ObjectGrab.transform.parent = null;
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
