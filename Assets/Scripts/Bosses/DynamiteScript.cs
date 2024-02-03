using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{

    //public GameObject dynamite;

    public SaltMineBoss saltMineBoss;
    public Rigidbody2D dynaRigidbody;
    public DynaSpawnScript dynaSpawn;
    public ExploSpawner explosion;

    Vector3 dynamitePos;

    /*public float spawnRate = 2;
    private float timer = 0;*/

    // Start is called before the first frame update
    void Start()
    {
        //dynamitePos = saltMineBoss.getSaltMineBossPos();
        //dynamite.
        //transform.position = dynamitePos + new Vector3(0.0f, 1.0f, 0.0f);
        transform.Rotate(0.0f, 0.0f, 45.0f, Space.Self);
        dynaRigidbody = GetComponent<Rigidbody2D>();
        saltMineBoss = GameObject.FindGameObjectWithTag("SaltMineBoss").GetComponent<SaltMineBoss>();
        dynaSpawn = GameObject.FindGameObjectWithTag("DynaSpawn").GetComponent<DynaSpawnScript>();
        explosion = GameObject.FindGameObjectWithTag("Explosion").GetComponent<ExploSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (saltMineBoss.IsThrown()){
            dynaRigidbody.velocity = transform.up * 50;
            transform.Rotate(0.0f, 0.0f, 90 * Time.deltaTime, Space.Self);
        }
        if (transform.position.y < 0.0f){
            //dynaSpawn.SetSpawnedOff();
            //saltMineBoss.SetThrownOff();
            explosion.SpawnExplo(transform.position);
            Destroy(gameObject);
        }
        /*if (saltMineBoss.IsThrown() && !dynaSpawn.IsSpawned()){
            if (timer >= spawnRate){
                saltMineBoss.
            }
        }*/
    }


    /*public Vector3 GetDynoPos(){
        return dynamitePos;
    }*/
}
