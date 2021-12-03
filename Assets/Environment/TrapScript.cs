using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public int damage;

    //To be used for traps that deal damage only once
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.collider.gameObject.CompareTag("Player"))
    //     {
    //         collision.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
    //     }
    // }

    //To be used with traps that deal continuous damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            if (!collision.collider.gameObject.GetComponent<PlayerStats>().isInvinsible) {
                collision.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            }
        }
    }
}
