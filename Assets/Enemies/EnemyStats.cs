using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;

    private void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
         currHealth -= damage;
        
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
