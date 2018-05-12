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

    public Slider Hp_Slider;

    public Camera cameraToLookAt;

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

        Hp_Slider.GetComponent<RectTransform>().position = cameraToLookAt.GetComponent<Camera>().WorldToScreenPoint(cameraToLookAt.gameObject.transform.position + new Vector3(0f, 1f, 0f));

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

    public void AddDammage(float dmg)
    {
        if (IsDead)
            return;
        HP -= dmg;
        if (HP <= 0)
        {
            HP = 0;
            agent.enabled = false;
            IsDead = false;
            anim.SetTrigger("Die");
            transform.GetChild(0).localPosition = new Vector3(0f, 0.25f, 0f);
            Destroy(gameObject, 0f);
            scr_SpawnEnemys.Osos--;
        }
        Hp_Slider.value = HP;
    }
}