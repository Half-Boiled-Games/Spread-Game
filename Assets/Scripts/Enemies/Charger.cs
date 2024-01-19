using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Charger : Enemy
{
    // The ratio of speedup during the fast portion of the charge
    float chargeSpeed = 1.5f;

    // The speed debuff amount applied after the charge
    float chargeRecover = .7f;

    // The amount of time the fast portion of the charge lasts
    float chargeSpeedTime = 0.3f;

    // The amount of time the entire charge lasts
    float chargeTotalTime = 0.6f;

    public override void Attack()
    {
        //The fast part of the charge
        if (attackCooldown >= chargeSpeedTime)
        {
            transform.position += moveVector * moveSpeed * chargeSpeed * Time.deltaTime;
        }
        //The recovery of the charge
        else if (attackCooldown >= chargeTotalTime)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            transform.position += moveVector * moveSpeed * chargeRecover * Time.deltaTime;
        }
        //Triggers when charge is over
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            base.currentState = EnemyState.Active;
        }

    }

    /*
     * Checks for collisions with the player, if the charger collides with the player, the player takes damage.
     */
    private void OnCollision2D(Collision2D collision)
    {
        //base.currentState == EnemyState.Attacking &&
        if ( collision.gameObject.tag == "Player")
        {
            base.player.TakeDamage(damage);
        }
    }

    public override bool canAttack()
    {
        // TODO Conditional checks
        return false;
    }

    public override bool IsKnockedOut()
    {
        // TODO Conditional checks
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.koTime = 10f;
        base.attackCooldown = 5f;
        base.damage = 50;
        base.moveSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
