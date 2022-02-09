using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public int xpToGive;
    public int level;

    private void Awake()
    {
        currHealth = maxHealth;
    }

    private void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerStats>().level > level)
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
            GameObject.Find("Player").GetComponent<PlayerStats>().AddXp(xpToGive);
        }
    }

    private void LevelUp()
    {
        maxHealth = 1.1f*maxHealth;
    }
}
