using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadling : Enemy
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    /*
    * Checks for collisions with the player, if the charger collides with the player, the player takes damage.
    */
    private void OnCollision2D(Collision2D collision)
    {
        //base.currentState == EnemyState.Attacking &&
        if (collision.gameObject.tag == "Player")
        {
            base.player.TakeDamage(damage);
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
    void Update()
    {
        
    }
}
