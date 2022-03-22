using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlam : Ability
{
    public bool direction;
    public float attackRange;
    public Vector2 boxSize;
    public float knockback;
    
    private float damage;

    void Awake()
    {
        cooldown = 3f;
        remainingCooldown = 0;
        abilityName = "Stomp";
        description = "Call on the old ones' strength and stomp the ground, sending enemies flying upwards for a short time.";
        damage = 50f;
        attackRange = 2.5f;
        boxSize = new Vector2(2*attackRange, 1f);
        enemyLayer = LayerMask.GetMask("Enemy");
        scriptName = "GroundSlam";
        knockback = 200f;
        isCasting = false;
        icon = Resources.Load<Sprite>("stomp_icon");
    }

    void Update()
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
            isCasting = true;
            direction = GameObject.Find("Player").GetComponent<PlayerMovement>().lookingRight;

            RaycastHit2D[] hits;

            if(direction)
            {
                hits = Physics2D.BoxCastAll(castPoint.position, boxSize, 0f, Vector2.right, -attackRange,enemyLayer);
            }
            else
            {
                hits = Physics2D.BoxCastAll(castPoint.position, boxSize, 0f, Vector2.left, attackRange,enemyLayer);
            }

            foreach(RaycastHit2D enemy in hits)
            {
                if(enemy.collider.gameObject.tag == "Enemy")
                {
                    enemy.collider.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                }
                else if(enemy.collider.gameObject.tag == "Boss")
                {
                    enemy.collider.gameObject.GetComponent<BossStats>().TakeDamage(damage);
                }
                enemy.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, knockback));
            }

            remainingCooldown = cooldown;
            isCasting = false;
        }
    }

    public override void LevelUp(int levelToGetTo)
    {
        while(level < levelToGetTo)
        {
            damage = 1.1f*damage;
            if(attackRange < 4f)
            {
                attackRange = 1.1f*attackRange;
                boxSize = new Vector2(2*attackRange, 1f);
                if(attackRange > 4f)
                {
                    attackRange = 4f;
                }
            }
            if(knockback < 400f)
            {
                knockback = 1.3f*knockback;
                if(knockback > 400f)
                {
                    knockback = 400f;
                }
            }
            level++;
        }
    }

    private void OnDrawGizmosSelected()  //For debugging purposes
    {
        Gizmos.color = Color.red;
        Vector2 start = new Vector2(castPoint.position.x, castPoint.position.y);
        Gizmos.DrawWireCube(start, boxSize);
    }
}
