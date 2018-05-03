using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UniatChan_Scr : MonoBehaviour
{
    public Transform [] waypoint;

    int index;
    Animator anim;
    NavMeshAgent agent;
    bool viendo, atCheckpoint;
    float timer;

    private void Start()
    {
        atCheckpoint = false;
        timer = 0;
        index = 0;
        viendo = false;
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        NewWaypoint();
    }

    private void Update()
    {
        if (index < waypoint.Length)
        {
            agent.updateRotation = true;
            if (Vector3.Distance(this.transform.position, waypoint[index].position) < 1)
                ChangeState();
        }


        if (Input.GetButton("Jump") && viendo)
            Picar();

        if (atCheckpoint && timer < 7)
            timer += Time.deltaTime;
        else if (atCheckpoint)
            NewWaypoint();

    }

    void ChangeState()
    {
        if (Vector3.Distance(this.transform.position, waypoint[index].position) < 1)
        {
            index++;
            if (index == waypoint.Length)
                Ganar();
            else
            {
                Checkpoint();
            }
        }
    }

    void Ganar()
    {
        anim.SetBool("Walking", false);
        anim.SetTrigger("Dance");
    }

    void NewWaypoint()
    {
        agent.SetDestination(waypoint[index].position);
        anim.SetBool("Walking", true);
        atCheckpoint = false;
    }

    void Checkpoint()
    {
        anim.SetBool("Walking", false);
        anim.SetTrigger("Jump");
        atCheckpoint = true;
        timer = 0;
    }

    public void CambiarViendo()
    {
        viendo = !viendo;
    }

    public void Picar()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            anim.SetTrigger("Jump");
    }
}