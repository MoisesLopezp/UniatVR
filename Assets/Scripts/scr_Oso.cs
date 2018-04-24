using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_Oso : MonoBehaviour {

    NavMeshAgent Nav;
    Animation Anim;

    public GameObject Target;

    float HP = 100f;

    bool IsDead = false;

	// Use this for initialization
	void Start () {
        //Target = FindObjectOfType<UniatChan_Scr>().gameObject;
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponentInChildren<Animation>();
        Anim.Play("Walk");
    }
	
	// Update is called once per frame
	void Update () {
        if (Nav.enabled)
        {
            Nav.SetDestination(Target.transform.position);
            if (Nav.isStopped && Anim.IsPlaying("Run"))
            {
                Nav.isStopped = false;
            }
            if (Vector3.Distance(transform.position, Target.transform.position)<1f)
            {
                Nav.isStopped = true;
                Anim.Play("Claws Attack 1");
                Anim.PlayQueued("Run");
            }
        }
        
	}

    public void AddDammage(float dmg)
    {
        HP -= dmg;
        if (HP<=0)
        {
            HP = 0;
            Nav.isStopped = true;
            Nav.enabled = false;
            IsDead = false;
            Anim.Play("Death");
        } else
        {
            Anim.Play("Hit");
            Nav.isStopped = true;
            Anim.PlayQueued("Run");
        }
    }
}
