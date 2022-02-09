using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlam : Ability
{
    public bool direction;
    public float attackRange;
    public Vector2 boxSize;
    public float knockback;
    public static new string abilityName;
    public static new string description;
    public static new Sprite icon;
    
    private float damage;

    void Awake()
    {
        cooldown = 3f;
        remainingCooldown = 0;
        abilityName = "Deep Stomp";
        description = "Call on the old ones' strength and stomp the ground, sending enemies flying upwards for a short time.";
        damage = 50f;
        attackRange = 2.5f;
        boxSize = new Vector2(2*attackRange, 1f);
        enemyLayer = LayerMask.GetMask("Enemy");
        scriptName = "GroundSlam";
        knockback = 200f;
        isCasting = false;
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
            direction = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().lookingRight;

            RaycastHit2D[] hits;

            if(direction)
            {
                hits = Physics2D.BoxCastAll(castPoint.position, boxSize, 0f, Vector2.right, -attackRange,enemyLayer);
                // Vector3 dir = castPoint.transform.TransformDirection(Vector3.right) * attackRange;  //For debugging purposes
                // Debug.DrawRay(castPoint.position, dir, Color.red);
            }
            else
            {
                hits = Physics2D.BoxCastAll(castPoint.position, boxSize, 0f, Vector2.left, attackRange,enemyLayer);
                // Vector3 dir = castPoint.transform.TransformDirection(Vector3.left) * -attackRange;  //For debugging purposes
                // Debug.DrawRay(castPoint.position, dir, Color.red);
            }

            foreach(RaycastHit2D enemy in hits)
            {
                enemy.collider.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                enemy.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, knockback));
            }

            remainingCooldown = cooldown;
            isCasting = false;
        }
    }

    public override void LevelUp(int levelToGetTo)
    {
        
    }

    private void OnDrawGizmosSelected()  //For debugging purposes
    {
        Gizmos.color = Color.red;
        Vector2 start = new Vector2(castPoint.position.x, castPoint.position.y);
        Gizmos.DrawWireCube(start, boxSize);
    }
}
