using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerColor_Scr : MonoBehaviour
{
    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void PointEnemy()
    {
        renderer.material.SetColor("_Color", Color.red);
    }
	
    public void PointFriend()
    {
        renderer.material.SetColor("_Color", Color.green);
    }

    public void PointNothing()
    {
        renderer.material.SetColor("_Color", Color.white);
    }
}
