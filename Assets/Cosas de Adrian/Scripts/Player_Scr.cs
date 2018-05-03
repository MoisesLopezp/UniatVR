using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Scr : MonoBehaviour
{
    Transform camara_transform;
    MenuPause_Scr pausa;

    private void Start()
    {
        pausa = FindObjectOfType<MenuPause_Scr>();
        camara_transform = this.transform.GetChild(0).GetComponent<Transform>();   
    }

    void Update ()
    {
        this.transform.Translate(camara_transform.forward * Time.deltaTime * 3 * Input.GetAxis("Vertical"));
        this.transform.Translate(camara_transform.right * Time.deltaTime * 3 * Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.P))
            pausa.Pausa();
    }
}