using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bosses : MonoBehaviour
{

    public Player player;
    public enum BossState
    {
        Attacking,
        KnockedOut,
        Active,
        Defeated
    }

    [SerializeField]
    protected int damage;

    [SerializeField]
    protected float moveSpeed;

    float attackTimer;

    [SerializeField]
    protected float attackCoolDown;

    [SerializeField]
    protected float koTime;

    float currentKOTime;

    /*[SerializeField]
    protected int lives;*/

    int currentLives;

    public BossState currentState;

    protected Vector3 moveVector;


    // Start is called before the first frame update
    void Start()
    {
        currentState = BossState.Active;
        attackTimer = 0f;
        currentKOTime = 0f;
        currentLives = 3;
        moveVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (currentKOTime < koTime)
        {
            currentKOTime += Time.deltaTime;
        }*/

        /*if (attackTimer < attackCooldown)
        {
            attackTimer += Time.deltaTime;
        }*/



        switch (currentState)
        {
            case BossState.Active:
                if (IsKnockedOut())
                {
                    Knockout();
                }


                if (canAttack())
                {
                    currentState = BossState.Attacking;
                    Attack();
                }

                break;
            case BossState.Attacking:

                break;
            case BossState.KnockedOut:
                if (currentLives == 0)
                {
                    Defeat();
                }
                if (currentKOTime == koTime)
                {
                    WakeUp();
                }
                if (currentKOTime < koTime)
                {
                    currentKOTime += Time.deltaTime;
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
    public bool canAttack()
    {
        if (attackTimer < attackCoolDown)
        {
            attackTimer += Time.deltaTime;
            return false;
        }
        return true;
    }

    /*
     * Checks if the enemy is knockout. Returns True if the enemy's knockout criteria is met, False otherwise
     */
    public abstract bool IsKnockedOut();

    /*
     * Sets an enemy in the Active state to the KnockedOut state
     */
    public void Knockout()
    {
        currentState = BossState.KnockedOut;
        currentKOTime = 0f;
        currentLives -= 1;
    }
    /*
    * Sets an enemy in the KnockedOut state to the Active state
    */
    public void WakeUp()
    {
        currentState = BossState.Active;
        currentKOTime = 0f;
    }

    //Sets an enemy in the KnockedOut state to the Defeated state
    public void Defeat()
    {
        currentState = BossState.Defeated;
    }
}
