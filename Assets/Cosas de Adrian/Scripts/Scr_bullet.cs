using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_bullet : MonoBehaviour {
	
	void Update ()
    {
        Destroy(this.gameObject, 5);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Bear"))
            c.gameObject.GetComponent<scr_Oso>().AddDammage(50);
        Destroy(this.gameObject);
    }
}