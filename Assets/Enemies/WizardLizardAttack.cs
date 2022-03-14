using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLizardAttack : Ability
{
    public GameObject WizShotPrefab;
    public SpriteDirection projDirection;

    public bool enemyLookingRight;
    private float damage;

    private void Start()
    {
        remainingCooldown = cooldown;
        damage = WizShotPrefab.GetComponent<Projectile>().damage;
    }

    private void Update()
    {
        remainingCooldown -= Time.deltaTime;
    }

    public override void Cast()
    {
        if(remainingCooldown <= 0)
        {
            GameObject  WizShotObj = Instantiate(WizShotPrefab, castPoint.position, Quaternion.identity);

            enemyLookingRight = gameObject.GetComponent<BasicEnemyAI>().lookingRight;
            if(enemyLookingRight)
            {
                projDirection = SpriteDirection.Right;
            }
            else
            {
                projDirection = SpriteDirection.Left;
            }

            WizShotObj.GetComponent<Projectile>().spriteDirection = projDirection;
            WizShotObj.GetComponent<Projectile>().damage = damage;
            WizShotObj.GetComponent<Projectile>().CheckDirection();
            WizShotObj.GetComponent<Projectile>().MoveProjectile();

            remainingCooldown = cooldown;
        }
    }

    public override void LevelUp(int levelToGetTo)
    {
        while(level < levelToGetTo)
        {
            damage = 1.1f*damage;
            level++;
        }
    }
}
