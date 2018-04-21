using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniatChan_Scr : MonoBehaviour
{
    public void Picar()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
    }
}