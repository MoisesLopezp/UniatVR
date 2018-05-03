using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HandsControl : MonoBehaviour {

    public Transform Player;

    public float plusRot = 0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0f, plusRot, 0f);
        transform.position = Player.transform.position;
    }
}
