﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause_Scr : MonoBehaviour
{
    bool pause;
    public GameObject menu;

    private void Start()
    {
        pause = false;
    }

    public void Pausa()
    {
        pause = !pause;

        if (pause)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            menu.transform.position = this.transform.position;
            menu.transform.eulerAngles = this.transform.rotation.eulerAngles;
        }

        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continuar()
    {
        Pausa();
    }
}