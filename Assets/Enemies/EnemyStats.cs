using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public int xpToGive;
    public int level;
    public Ability enemyAttack;
    public PlayerStats playerStats = null;

    private void Awake()
    {
        currHealth = maxHealth;
    }

    private void Update()
    {
        if(playerStats == null)
        {
            playerStats = (PlayerStats)GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        }
        if(playerStats.level > level)
        {
            LevelUp();
        }
    }

    public void TakeDamage(float damage)
    {
         currHealth -= damage;
        
        if (currHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.AddXp(xpToGive);
        }
    }

    private void LevelUp()
    {
        maxHealth = 1.1f*maxHealth;
        level = playerStats.level;
        enemyAttack.LevelUp(level);
    }
}
