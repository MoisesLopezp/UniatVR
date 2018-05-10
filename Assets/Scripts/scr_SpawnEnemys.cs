using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SpawnEnemys : MonoBehaviour {

    public static bool CanSpawn = true;

    public static int Osos = 0;

    public GameObject Enemy;

    public Transform[] Points = new Transform[3];

    float time_spawn = 10f;

    public GameObject TargetEnemy;

	// Use this for initialization
	void Start () {
        CanSpawn = true;
        Osos = 0;
        StartCoroutine(SpawnLoop());
        TargetEnemy = FindObjectOfType<UniatChan_Scr>().gameObject;
    }

    IEnumerator SpawnLoop()
    {
        while (CanSpawn)
        {
            yield return new WaitForSeconds(time_spawn);

            if (Osos > 5)
                continue;

            GameObject oso = Instantiate(Enemy, Points[Random.Range(0,Points.Length)].position, Quaternion.identity);
            oso.GetComponent<scr_Oso>().Target = TargetEnemy;
            Osos++;
            if (time_spawn>5f)
            {
                time_spawn -= 0.2f;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
