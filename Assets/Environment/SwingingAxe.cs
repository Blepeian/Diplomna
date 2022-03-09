using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (!col.gameObject.GetComponent<PlayerStats>().isInvinsible) {
                col.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            }
        }
    }
}
