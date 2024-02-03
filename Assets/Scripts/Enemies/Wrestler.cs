using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrestler : Enemy
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
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
        base.koTime = 10f;
        base.attackCooldown = 5f;
        base.damage = 100;
        base.moveSpeed = 30f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
