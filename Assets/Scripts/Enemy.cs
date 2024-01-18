using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    enum EnemyState
    {
        Attacking,
        KnockedOut,
        Active
    }

    [SerializeField]
    int maxHealth;

    int health;

    [SerializeField]
    int damage;

    [SerializeField]
    float moveSpeed;

    float attackTimer;

    [SerializeField]
    float attackCooldown;

    [SerializeField]
    float koTime;

    float currentKOTime;

    EnemyState currentState;

    Vector3 moveVector;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        currentState = EnemyState.Active;
        attackTimer = 0f;
        currentKOTime = 0f;
        moveVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentKOTime > koTime)
        {
            currentKOTime -= Time.deltaTime;
        }

        if (attackTimer > attackCooldown)
        {
            attackTimer -= Time.deltaTime;
        }



        switch(currentState)
        {
            case EnemyState.Active:
                if (IsKnockedOut())
                {
                    Knockout();
                }

                // TODO Put logic here for attack and movement checks

                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.KnockedOut:
                if (currentKOTime == 0f)
                {
                    WakeUp();
                }
                break;
        }
    }

    /*
     * Attacks a player
     */
    public abstract void Attack();

    /*
     * Checks if the enemy is knockout. Returns True if the enemy's knockout criteria is met, False otherwise
     */
    public abstract bool IsKnockedOut();

    /*
     * Sets an enemy in the Active state to the KnockedOut state
     */
    public void Knockout()
    {
        currentState = EnemyState.KnockedOut;
        currentKOTime = koTime;
    }
    /*
    * Sets an enemy in the KnockedOut state to the Active state
    */
    public void WakeUp()
    {
        currentState = EnemyState.Active;
        currentKOTime = 0f;
    }


}
