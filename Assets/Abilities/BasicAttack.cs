using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Ability
{
    
    [SerializeField] private float damage;
    public float attackRange;

    private void Awake()
    {
        cooldown = 0.5f;
        remainingCooldown = 0;
        abilityName = "Stab";
        description = "Stab enemies with your dagger. Deals low damage but attacks fast.";
        damage = 25f;
        attackRange = 0.45f;
        enemyLayer = LayerMask.GetMask("Enemy");
        scriptName = "BasicAttack";
        icon = Resources.Load<Sprite>("Stab_Icon");
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
            isCasting = true;
            Collider2D[] hits = Physics2D.OverlapCircleAll(castPoint.position, attackRange, enemyLayer);

            foreach(Collider2D enemy in hits)
            {
                if(enemy.gameObject.tag == "Enemy")
                {
                    enemy.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                }
                else if(enemy.gameObject.tag == "Boss")
                {
                    enemy.gameObject.GetComponent<BossStats>().TakeDamage(damage);
                }  
            }
            remainingCooldown = cooldown;
            isCasting = false;
        }
    }
    
    public override void LevelUp(int levelToGetTo)
    {
        while(level < levelToGetTo)
        {
            damage = 1.15f*damage;
            level++;
        }
    }
    
    // private void OnDrawGizmosSelected()  //For debugging purposes
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(castPoint.position, attackRange);
    // }
}
