using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/////////////////////DEBUG///////////////
using UnityEngine.UI;

public class Player_Scr : MonoBehaviour
{
    Transform camara_transform;
    MenuPause_Scr pausa;

    /////////////////////DEBUG////////////////
    public Text text;

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

        /////////////////////DEBUG///////////////
        if (Input.GetButton("Fire1"))
            text.text = "Fire1";
        if (Input.GetButton("Fire2"))
            text.text = "Fire2";
        if (Input.GetButton("Fire3"))
            text.text = "Fire3";
        if (Input.GetButton("Jump"))
            text.text = "jump";

    }
}