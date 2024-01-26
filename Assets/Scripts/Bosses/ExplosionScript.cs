using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public SaltMineBoss saltMineBoss;
    public DynaSpawnScript dynaSpawn;

    //Vector3 exploPos;

    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        saltMineBoss = GameObject.FindGameObjectWithTag("SaltMineBoss").GetComponent<SaltMineBoss>();
        dynaSpawn = GameObject.FindGameObjectWithTag("DynaSpawn").GetComponent<DynaSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (saltMineBoss.IsThrown() && dynaSpawn.IsSpawned()){
            if (timer >= spawnRate){
                //timer = 0;
                dynaSpawn.SetSpawnedOff();
                saltMineBoss.SetThrownOff();
                Destroy(gameObject);
            }
            timer += Time.deltaTime;
        }
    }

    /*public void SpawnExplo(Vector3 dynaPos){
        transform.position = dynaPos;
    }*/
}
