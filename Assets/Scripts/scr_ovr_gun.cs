using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ovr_gun : MonoBehaviour {

    float CD = 0f;

    public ParticleSystem Effect;
    public GameObject Cannon;
    public GameObject HitEffect;

    Animator MyAnim;

    public LayerMask MaskShoot;

    private void Start()
    {
        MyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (CD > 0f)
            CD -= Time.deltaTime;

        Debug.DrawRay(Cannon.transform.position, Cannon.transform.forward,Color.red);
    }

    public void Touch_Acction()
    {
        if (CD<=0f)
        {
            Shoot();
            CD = 0.5f;
        }
    }

    public void Shoot()
    {
        Effect.Play();
        MyAnim.SetTrigger("Shoot");
        Ray shoot = new Ray(Cannon.transform.position, Cannon.transform.forward);
        RaycastHit hit;
        Physics.Raycast(shoot,out hit, MaskShoot);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.CompareTag("Bear"))
            {
                hit.transform.gameObject.SendMessage("AddDammage", 30);
            }
            GameObject hitef = Instantiate(HitEffect, hit.point, Quaternion.identity);
            Destroy(hitef, 0.5f);
        }
    }
}
