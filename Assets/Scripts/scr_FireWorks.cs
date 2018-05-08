using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FireWorks : MonoBehaviour {

    public Rigidbody[] Animals = new Rigidbody[3];

    public GameObject[] FireWorks = new GameObject[3];

    public void StartParty()
    {
        StartCoroutine(PartyLoop());
    }

    IEnumerator PartyLoop()
    {
        for (int i = 0; i < FireWorks.Length; i++)
            FireWorks[i].SetActive(true);

        while(true)
        {
            for (int i = 0; i < Animals.Length; i++)
            {
                if (Animals[i].useGravity)
                    Animals[i].AddForce(new Vector3(0f, 3f, 0f), ForceMode.Impulse);
            }

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("UniatChan"))
        {
            StartParty();
        }
    }

}
