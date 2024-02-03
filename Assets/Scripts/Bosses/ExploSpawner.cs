using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploSpawner : MonoBehaviour
{

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnExplo(Vector3 dynaPos){
        Instantiate(explosion, dynaPos, transform.rotation);
        //transform.position = dynaPos;
    }
}
