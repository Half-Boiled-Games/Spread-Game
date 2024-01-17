using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //References to game objects
    [SerializeField]
    Player player;

    //References to prefabs
    [SerializeField]
    PlayerProjectile playerProjectile;

    //Lists
    List<PlayerProjectile> playerProjectiles;

    void Start()
    {
        playerProjectiles = new List<PlayerProjectile>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Instantiates a new player projectile in the specified direction
    /// </summary>
    /// <param name="direction">Direction to shoot projectile</param>
    public void AddPlayerProjectile(Vector2 direction)
    {
        PlayerProjectile projectile = Instantiate(playerProjectile, player.transform.position, Quaternion.identity);
        projectile.SetDirection(direction.normalized);
        playerProjectiles.Add(projectile);
    }
}
