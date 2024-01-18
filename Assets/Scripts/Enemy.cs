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


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        currentState = EnemyState.Active;
        attackTimer = 0f;
        currentKOTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsKnockedOut())
        {
            Knockout();
        }

        switch(currentState)
        {
            case EnemyState.Active:
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

    public abstract void Attack();

    public abstract bool IsKnockedOut();
    public void Knockout()
    {
        currentState = EnemyState.KnockedOut;
        currentKOTime = koTime;
    }

    public void WakeUp()
    {
        currentState = EnemyState.Active;
        currentKOTime = 0f;
    }


}
