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

    private SpriteRenderer rend;
    private float hitColorTime;

    private void Awake()
    {
        currHealth = maxHealth;
        rend = gameObject.GetComponent<SpriteRenderer>();
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

        hitColorTime -= Time.deltaTime;
        if(hitColorTime <= 0)
        {
            rend.color = new Color(255f, 255f, 255f );
        }
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        rend.color = new Color(255f, 0f, 126f );
        hitColorTime = 0.5f;       
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
        this.enemyAttack.LevelUp(level);
    }
}
