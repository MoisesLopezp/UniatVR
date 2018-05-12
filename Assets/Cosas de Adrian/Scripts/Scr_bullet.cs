using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_bullet : MonoBehaviour
{
    Transform cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>().transform;
    }
    void Update ()
    {
        this.transform.Translate(cam.forward * Time.deltaTime * -30);
	}

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Bear"))
        {
            c.gameObject.GetComponent<scr_Oso>().AddDammage(50);
            Debug.Log("ouch");
        }
        Destroy(this.gameObject,5f);
    }
}
