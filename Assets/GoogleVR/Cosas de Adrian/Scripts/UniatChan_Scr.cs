using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniatChan_Scr : MonoBehaviour
{
    Animator anim;
    bool viendo;

    private void Start()
    {
        viendo = false;
        anim = this.GetComponent<Animator>();    
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && viendo)
            Picar();
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