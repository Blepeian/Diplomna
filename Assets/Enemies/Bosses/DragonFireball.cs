using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireball : Ability
{
    public GameObject FireBallPrefab;
    public SpriteDirection projDirection;

    public bool enemyLookingRight;
    private float damage;

    private void Start()
    {
        remainingCooldown = cooldown;
        damage = FireBallPrefab.GetComponent<Projectile>().damage;
    }

    private void Update()
    {
        remainingCooldown -= Time.deltaTime;
    }

    public override void Cast()
    {
        if(remainingCooldown <= 0)
        {
            GameObject  FireBallObj = Instantiate(FireBallPrefab, castPoint.position, Quaternion.identity);

            enemyLookingRight = gameObject.GetComponent<DragonAI>().lookingRight;
            if(enemyLookingRight)
            {
                FireBallObj.GetComponent<Projectile>().spriteDirection = SpriteDirection.Right;
            }
            else
            {
                FireBallObj.GetComponent<Projectile>().spriteDirection = SpriteDirection.Left;
            }

            FireBallObj.GetComponent<Projectile>().damage = damage;
            FireBallObj.GetComponent<Projectile>().CheckDirection();
            FireBallObj.GetComponent<Projectile>().MoveProjectile();

            remainingCooldown = cooldown;
        }
    }

    public override void LevelUp(int levelToGetTo){}
}
