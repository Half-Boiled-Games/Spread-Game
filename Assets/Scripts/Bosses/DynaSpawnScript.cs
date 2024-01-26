using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynaSpawnScript : MonoBehaviour
{

    public SaltMineBoss saltMineBoss;

    public GameObject dynamite;

    private bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (saltMineBoss.IsThrown() && !spawned){
            SpawnDyna();
        }
    }

    private void SpawnDyna(){
        spawned = true;
        Instantiate(dynamite, saltMineBoss.GetPos()+new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
    }

    public void SetSpawnedOff(){
        spawned = false;
    }

    public bool IsSpawned(){
        return (spawned);
    }

}
