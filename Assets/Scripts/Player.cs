using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameController controller;

    //Player Control Code Variables

    ///Player Input Actions
    InputActions actions;

        ///Player States
    enum PlayerState
    {
        Controlling,
        Dodging,
    }

    PlayerState currentState;

        ///Gameplay variables
    Vector3 moveVector;
    Vector3 fireVector;

    float dodgeTimer;
    bool dodgeInvincibility;

    float fireTimer;

    [SerializeField]
    int maxHealth = 100;

    public int health;

    //Player Control Settings Variables
    /// Move settings
    [SerializeField]
    float speed = 5f;

        /// Dodge settings
    //The ratio of speedup during the fast portion of the dodge
    [SerializeField]
    float dodgeSpeed = 1.5f;

    //The slow amount for the latter point of the dodge roll
    [SerializeField]
    float dodgeSlow = 0.7f;

    //The amount of time the player is invincible while dodging
    [SerializeField]
    float dodgeInvincibilityTime = 0.35f; ///Dodge invincibility time should be slightly longer than dodge speed time, for player feel

    //The amount of time the fast portion of the dodge lasts
    [SerializeField]
    float dodgeSpeedTime = 0.3f;

    //The amount of time the entire dodge lasts
    [SerializeField]
    float dodgeTotalTime = 0.6f;

    ///Fire settings
    //The delay between shots
    [SerializeField]
    float fireDelay = 0.5f;






    private void Awake()
    {
        //Player Input
        actions = new InputActions();
        actions.Player.Fire.performed += OnFire;
        actions.Player.Dodge.performed += OnDodge;


    }

    void Start()
    {
        //Initializing Control Code Variable Values
        currentState = PlayerState.Controlling;

        moveVector = Vector3.zero;
        fireVector = Vector3.zero;

        dodgeTimer = 0.0f;
        dodgeInvincibility = false;

        fireTimer = 0.0f;
        health = maxHealth;
    }

    void Update()
    {
        //Player Input

        if (fireTimer < fireDelay)
        {
            fireTimer += Time.deltaTime;
        }
        
        switch (currentState)
        {
            case PlayerState.Controlling:
                moveVector = actions.Player.Move.ReadValue<Vector2>();
                fireVector = Camera.main.ScreenToWorldPoint(actions.Player.Aim.ReadValue<Vector2>()) - transform.position;

                transform.position += moveVector * speed * Time.deltaTime;
                break;

            case PlayerState.Dodging:
                dodgeTimer += Time.deltaTime;

                //Disables invincibility frames for the last part of the dodge
                if (dodgeInvincibility && dodgeTimer >= dodgeInvincibilityTime)
                {
                    
                    dodgeInvincibility = false;
                }
                //The fast part of the dodge
                if (dodgeTimer <= dodgeSpeedTime)
                {
                    transform.position += moveVector * speed * dodgeSpeed * Time.deltaTime;
                }
                //The recovery of the dodge
                else if (dodgeTimer <= dodgeTotalTime)
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    transform.position += moveVector * speed * dodgeSlow * Time.deltaTime;
                }
                //Triggers when dodge is over
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                    currentState = PlayerState.Controlling;
                }

                break;

            default:
                Debug.LogError("Player reached bad state: \"" + currentState + "\" in Update");
                break;
        }


    }

    /// <summary>
    /// Activates when the player inputs "fire"
    /// </summary>
    /// <param name="context"></param>
    private void OnFire(InputAction.CallbackContext context)
    {
        switch (currentState)
        {
            case PlayerState.Controlling:
                //Checks if the delay has passed between shots
                if (fireTimer >= fireDelay)
                {
                    controller.AddPlayerProjectile(fireVector);
                    fireTimer = 0.0f;
                }
                else
                {

                }
                break;

            case PlayerState.Dodging:
                break;

            default:
                Debug.LogError("Player reached bad state: \"" + currentState + "\" in OnFire");
                break;
        }
    }

    /// <summary>
    /// Activates when the player inputs "dodge"
    /// </summary>
    /// <param name="context"></param>
    private void OnDodge(InputAction.CallbackContext context)
    {
        switch (currentState)
        {
            case PlayerState.Controlling:
                //Checks if there is a direction to dodge in
                if(moveVector != Vector3.zero)
                {
                    //Debug
                    GetComponent<SpriteRenderer>().color = Color.green;

                    currentState = PlayerState.Dodging;
                    dodgeTimer = 0.0f;
                    dodgeInvincibility = true;
                }
                else
                {

                }
                break;

            case PlayerState.Dodging:
                break;

            default:
                Debug.LogError("Player reached bad state: \"" + currentState + "\" in OnDodge");
                break;
        }

    }
    /*
     * Deals a specified amount of damage to the player
     */
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        actions.Player.Enable();
    }
    private void OnDisable()
    {
        actions.Player.Disable();
    }

}
