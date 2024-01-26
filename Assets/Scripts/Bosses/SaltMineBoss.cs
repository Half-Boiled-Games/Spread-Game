using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaltMineBoss : Bosses
{

    //public GameObject saltMineBoss;

    //public DynamiteScript dynamite;

    //public Rigidbody2D dynoRigidbody;

    private bool thrown;

    Vector3 saltMineBossPos;
    //Vector3 dynoPos;

    // Start is called before the first frame update
    void Start()
    {
        saltMineBossPos = new Vector3(0.0f, 0.0f, 0.0f);
        //saltMineBoss.
        transform.position = saltMineBossPos;
        thrown = false;
        //dynoRigidbody = dynamite.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!thrown){
            Throw();
        }
        //if (dynamite.transform.position.y != 0.0f){
        //    Throw();
        //} else {
        //    dynoPos = dynamite.transform.position;
            //Destroy(dynamite.GetComponent<Rigidbody2D>());
        //}

    }

    public Vector3 GetPos()
    {
        return saltMineBossPos;
    }

    public override void Attack()
    {
    }

    private void Throw(){
        //dynoRigidbody.velocity = dynamite.transform.up * 50;
        //dynamite.transform.position += dynamite.transform.left * 5 * Time.deltaTime;
        //dynamite.transform.Rotate(0.0f, 0.0f, 90 * Time.deltaTime, Space.Self);
        thrown = true;
    }

    public bool IsThrown(){
        return (thrown);
    }

    public void SetThrownOff(){
        thrown = false;
    }

    public override bool IsKnockedOut()
    {
        return false;
    }
}
