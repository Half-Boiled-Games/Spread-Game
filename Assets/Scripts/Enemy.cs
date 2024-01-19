using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Player player;
    public enum EnemyState
    {
        Attacking,
        KnockedOut,
        Active
    }

    [SerializeField]
    protected int damage;

    [SerializeField]
    protected float moveSpeed;

    float attackTimer;

    [SerializeField]
    protected float attackCooldown;

    [SerializeField]
    protected float koTime;

    float currentKOTime;

    public EnemyState currentState;

    protected Vector3 moveVector;


    // Start is called before the first frame update
    void Start()
    {
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

                if (canAttack())
                {
                    currentState = EnemyState.Attacking;
                    Attack();
                }

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
     * Checks if the enemy can attack the player
     */
    public abstract bool canAttack();

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
