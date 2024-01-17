using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Control Settings Variables
    [SerializeField] 
    float speed = 6.0f;

    //Control code variables
    protected Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
