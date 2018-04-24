using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniatChan_Scr : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();    
    }

    public void Picar()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            anim.SetTrigger("Jump");
    }
}