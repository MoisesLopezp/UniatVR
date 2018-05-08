using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_Oso : MonoBehaviour {

    NavMeshAgent Nav;
    Animator Anim;

    public GameObject Target;

    float HP = 100f;

    bool IsDead = false;

	// Use this for initialization
	void Start () {
        //Target = FindObjectOfType<UniatChan_Scr>().gameObject;
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponentInChildren<Animator>();
        Anim.SetBool("Run",true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Nav.enabled && Target!=null)
        {
            Nav.SetDestination(Target.transform.position);
            if (Nav.isStopped && Anim.GetCurrentAnimatorClipInfo(0)[0].clip.name!="Hit")
            {
                Nav.isStopped = false;
            }
            if (Vector3.Distance(transform.position, Target.transform.position)<1.6f)
            {
                Nav.isStopped = true;
                Anim.SetTrigger("Attack");
            }
        }
        
	}

    public void AddDammage(float dmg)
    {
        if (IsDead)
            return;
        HP -= dmg;
        if (HP<=0)
        {
            HP = 0;
            Nav.enabled = false;
            IsDead = false;
            Anim.SetTrigger("Die");
            transform.GetChild(0).localPosition = new Vector3(0f,0.25f,0f);
        } else
        {
            Anim.SetTrigger("Hit");
            Nav.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") || other.CompareTag("CandGrab") && !IsDead)
        {
            AddDammage(30);
        }
    }
}
