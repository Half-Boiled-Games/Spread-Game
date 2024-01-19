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
        //The fast part of the dodge
        if (attackCooldown >= chargeSpeedTime)
        {
            transform.position += moveVector * moveSpeed * chargeSpeed * Time.deltaTime;
        }
        //The recovery of the dodge
        else if (attackCooldown >= chargeTotalTime)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            transform.position += moveVector * moveSpeed * chargeRecover * Time.deltaTime;
        }
        //Triggers when dodge is over
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            base.currentState = EnemyState.Active;
        }

    }

    private void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        base.moveSpeed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
