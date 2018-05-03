using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCube_Scr : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("Fire1"))
            this.GetComponent<Renderer>().material.color = Color.green;
        if (Input.GetButton("Fire2"))
            this.GetComponent<Renderer>().material.color = Color.red;
        if (Input.GetButton("Fire3"))
            this.GetComponent<Renderer>().material.color = Color.blue;
        if (Input.GetButton("Jump"))
            this.GetComponent<Renderer>().material.color = Color.black;
        
        //a = jump
        //b = fire1
        //c = fire2
        //d = fire3
    }
}
