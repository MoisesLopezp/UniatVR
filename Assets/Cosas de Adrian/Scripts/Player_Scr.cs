using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Scr : MonoBehaviour
{
    public GameObject particle;
    public GameObject bullet;

    Transform camara_transform;
    MenuPause_Scr pausa;
    float timer;
    bool fireing;

    private void Start()
    {
        fireing = false;
        pausa = FindObjectOfType<MenuPause_Scr>();
        camara_transform = this.transform.GetChild(0).GetComponent<Transform>();   
    }

    void Update ()
    {
        this.transform.Translate(camara_transform.forward * Time.deltaTime * 3 * Input.GetAxis("Vertical"));
        this.transform.Translate(camara_transform.right * Time.deltaTime * 3 * Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Jump"))
            pausa.Pausa();

        if ((Input.GetButtonDown("Fire3") && !fireing) || (Input.GetMouseButtonDown(0) && !fireing))
            Fire();

        if (fireing)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                fireing = false;
                particle.SetActive(false);
                timer = 0;
            }
        }
    }

    void Fire()
    {
        Debug.Log("pew");
        fireing = true;
        particle.SetActive(true);
        Instantiate(bullet, particle.transform);
    }
}