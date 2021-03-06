using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : Ability
{
    public bool direction;
    public float attackRange;
    public float duration;
    
    private float remainingDuration;
    [SerializeField] private float damage;

    void Awake()
    {
        cooldown = 3f;
        remainingCooldown = 0;
        abilityName = "Death Ray";
        description = "Chant a spell from your necronomicon, firing a ray of death borrowed from the old gods' powers.";
        damage = 0.05f;
        attackRange = 4f;
        enemyLayer = LayerMask.GetMask("Enemy");
        duration = 1.5f;
        remainingDuration = 0;
        scriptName = "LaserAttack";
        isCasting = false;
        icon = Resources.Load<Sprite>("death_ray_icon");
    }

    void Update()
    {
        if(remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }

        if(remainingDuration > 0)
        {
            remainingDuration -= Time.deltaTime;
            if(remainingDuration <= 0)
            {
                remainingCooldown = cooldown;
                isCasting = false;
            }
            else
            {
                Laser();
            }
        }
    }

    public override void Cast()
    {
        if(remainingCooldown <= 0)
        {
            if(remainingDuration <= 0)
            {
                isCasting = true;
                remainingDuration = duration;
                Laser();
            }
        }
    }

    public override void LevelUp(int levelToGetTo)
    {
        while(level < levelToGetTo)
        {
            damage = 1.05f*damage;
            if(attackRange < 8f)
            {
                attackRange = 1.1f*attackRange;
                if(attackRange > 8f)
                {
                    attackRange = 8f;
                }
            }
            level++;
        }
    }

    private void Laser()
    {
        direction = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().lookingRight;

        RaycastHit2D[] hits;

        if(direction)
        {
            hits = Physics2D.RaycastAll(castPoint.position, Vector2.right, attackRange, enemyLayer);
            // Vector3 dir = castPoint.transform.TransformDirection(Vector3.right) * attackRange;  //For debugging purposes
            // Debug.DrawRay(castPoint.position, dir, Color.red);
        }
        else
        {
            hits = Physics2D.RaycastAll(castPoint.position, Vector2.left, attackRange, enemyLayer);
            // Vector3 dir = castPoint.transform.TransformDirection(Vector3.left) * -attackRange;  //For debugging purposes
            // Debug.DrawRay(castPoint.position, dir, Color.red);
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
        }
    }
}
