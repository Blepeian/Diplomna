using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Ability
{
    
    [SerializeField] private float damage;
    public float attackRange;
    public static new string abilityName;
    public static new string description;
    public static new Sprite icon;

    private void Awake()
    {
        cooldown = 0.2f;
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
            Debug.Log("Attacked " + hits.Length + " enemis");

            foreach(Collider2D enemy in hits)
            {
                enemy.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
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
