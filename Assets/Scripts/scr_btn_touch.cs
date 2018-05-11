using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_btn_touch : MonoBehaviour {

    public int Option = 0;

    Slider TimeSel;

    scr_ovr_menu mn;

    public OVRPlayerController player;

    float DelaySelect = 0f;

	// Use this for initialization
	void Start () {
        TimeSel = transform.GetChild(0).GetComponent<Slider>();
        mn = transform.root.GetComponent<scr_ovr_menu>();
    }
	
	// Update is called once per frame
	void Update () {
		if (DelaySelect>0f)
        {
            DelaySelect -= Time.deltaTime;
            if (DelaySelect <= 0f)
                SelectOp();
        }
        TimeSel.value = DelaySelect;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            DelaySelect = 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            DelaySelect = 0f;
        }
    }

    public void SelectOp()
    {
        switch (Option)
        {
            case 0:
                {
                    mn.Canvas.SetActive(false);
                    mn.UniatChan.SetActive(true);
                    mn.Enemys.SetActive(true);
                    player.Acceleration = 0.1f;
                }
                break;
            case 1:
                {
                    Application.Quit();
                }
                break;
            case 2:
                {
                    mn.Controlls.SetActive(!mn.Controlls.activeSelf);
                }
                break;
            case 3:
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
        }
    }
}
