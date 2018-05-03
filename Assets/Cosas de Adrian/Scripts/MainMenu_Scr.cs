using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Scr : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("CardboardVR");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
