using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalBaker : Enemy
{
    public GameObject breadling;

    public override void Attack()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(breadling, transform.position, transform.rotation);
        }
    }

    public override bool canAttack()
    {
        return false;
    }

    public override bool IsKnockedOut()
    {
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.koTime = 8f;
        base.attackCooldown = 4f;
        base.damage = 20;
        base.moveSpeed = 60f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
