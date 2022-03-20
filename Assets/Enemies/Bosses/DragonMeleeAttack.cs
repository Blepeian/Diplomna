using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMeleeAttack : Ability
{
    public float damage;
    public float attackRange;
    private LayerMask playerLayer;
    
    private bool enemyLookingRight;
    private Vector2 boxSize;

    private void Awake()
    {
        remainingCooldown = 0;
        playerLayer = LayerMask.GetMask("Player");
        boxSize = new Vector2(2*attackRange, 2*attackRange);
    }

    private void Update()
    {
        if(remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }

    public override void Cast()
    {
        
        if(remainingCooldown <= 0)
        {
            enemyLookingRight = gameObject.GetComponent<DragonAI>().lookingRight;

            RaycastHit2D hit;
            if(enemyLookingRight)
            {
                hit = Physics2D.BoxCast(castPoint.position, boxSize, 0f, Vector2.right, -attackRange, playerLayer);
            }
            else
            {
                hit = Physics2D.BoxCast(castPoint.position, boxSize, 0f, Vector2.left, attackRange, playerLayer);
            }

            hit.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);

            remainingCooldown = cooldown;
        }
    }

    public override void LevelUp(int levelToGetTo){}
}
