using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;

    private void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
         currHealth -= damage;
        
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
