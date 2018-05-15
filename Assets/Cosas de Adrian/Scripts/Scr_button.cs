using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_button : MonoBehaviour 
{
    public int accion;
    bool seleccionado;

    private void Update()
    {
        if (seleccionado && (Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0)))
            Boton(accion);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            seleccionado = true;
            Debug.Log("Hola");
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            seleccionado = false; ;
            Debug.Log("Adios");
        }
    }

    void Boton(int num)
    {
        switch (num)
        {
            case 0:
                SceneManager.LoadScene("CardboardVR");
                return;
            case 1:
                FindObjectOfType<MenuPause_Scr>().Pausa();
                return;
            case 2:
                SceneManager.LoadScene("Menu");
                return;
            default:
                Application.Quit();
                return;
        }
    }
}