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
    bool perder;

    private void Start()
    {
        perder = false;
        fireing = false;
        pausa = FindObjectOfType<MenuPause_Scr>();
        camara_transform = this.transform.GetChild(0).GetComponent<Transform>();   
    }

    void Update ()
    {
        if (perder)
            return;

        this.transform.Translate(camara_transform.forward * Time.deltaTime * 3 * Input.GetAxis("Vertical"));
        this.transform.Translate(camara_transform.right * Time.deltaTime * 3 * Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.P))
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

    public void Perder()
    {
        perder = true;
        FindObjectOfType<MenuPause_Scr>().Perder();
    }

    void Fire()
    {
        fireing = true;
        particle.SetActive(true);
        GameObject balin =  Instantiate(bullet, particle.transform.position, particle.transform.rotation);
        balin.GetComponent<Rigidbody>().AddForce(balin.transform.forward * 1500);
        balin.transform.parent = null;
    }
}