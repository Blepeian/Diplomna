using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Ability
{
    
    private int damage;
    public float attackRange;

    private void Start()
    {
        cooldown = 0.2f;
        remainingCooldown = cooldown;
        abilityName = "Stab";
        description = "Stab enemies with your dagger. Deals low damage but attacks fast.";
        damage = 5;
        attackRange = 0.45f;
        enemyLayer = LayerMask.GetMask("Enemy");
        scriptName = "BasicAttack";
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
            Collider2D[] hits = Physics2D.OverlapCircleAll(castPoint.position, attackRange, enemyLayer);
            Debug.Log("Attacked " + hits.Length + " enemis");

            foreach(Collider2D enemy in hits)
            {
                enemy.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            }
            remainingCooldown = cooldown;
            Debug.Log("On cooldown");
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(castPoint.position, attackRange);
 }
}
