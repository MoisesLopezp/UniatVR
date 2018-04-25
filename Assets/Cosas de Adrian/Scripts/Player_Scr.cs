using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Scr : MonoBehaviour
{
    Transform camara_transform;

    private void Start()
    {
        camara_transform = this.transform.GetChild(0).GetComponent<Transform>();   
    }

    void Update ()
    {
        this.transform.Translate(camara_transform.forward * Time.deltaTime * 3 * Input.GetAxis("Vertical"));
        this.transform.Translate(camara_transform.right * Time.deltaTime * 3 * Input.GetAxis("Horizontal"));
    }
}
