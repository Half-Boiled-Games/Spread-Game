using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassToucher : Enemy
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override bool canAttack()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsKnockedOut()
    {
        throw new System.NotImplementedException();
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
