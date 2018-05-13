using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UniatChan_Scr : MonoBehaviour
{
    public Transform [] waypoint;

    int index;
    Animator anim;
    NavMeshAgent agent;
    bool viendo, atCheckpoint;
    float timer;

    bool IsDead = false;
    float HP = 100f;

    public GameObject GO;
    public GameObject Enemys;

    public Slider Hp_Slider;

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
        if (!IsDead)
        {
            if (!agent.enabled)
                return;

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

            //Hp_Slider.GetComponent<RectTransform>().position = cameraToLookAt.GetComponent<Camera>().WorldToScreenPoint(cameraToLookAt.gameObject.transform.position + new Vector3(0f, 1f, 0f));
        }

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
        if (!agent.enabled)
            return;

        agent.SetDestination(waypoint[index].position);
        anim.SetBool("Walking", true);
        atCheckpoint = false;
    }

    void Checkpoint()
    {
        if (!agent.enabled)
            return;

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

    void Morir()
    {
        HP = 0;
        anim.SetBool("Walking", false);
        anim.SetBool("Cry", true);
        agent.enabled = false;
        IsDead = true;
        //Enemys.SetActive(false);
    }

    public void AddDammage(float dmg)
    {
        if (IsDead)
            return;
        HP -= dmg;
        if (HP <= 0)
        {
            Morir();
        }
        Hp_Slider.value = HP;
    }
}