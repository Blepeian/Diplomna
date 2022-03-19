using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public int damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
