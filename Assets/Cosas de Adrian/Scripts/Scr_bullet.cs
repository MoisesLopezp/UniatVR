using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_bullet : MonoBehaviour {
	
	void Update ()
    {
        this.transform.Translate(this.transform.forward * Time.deltaTime * 30);
	}

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Bear"))
            c.gameObject.GetComponent<scr_Oso>().AddDammage(50);
        Destroy(this.gameObject);
    }
}
