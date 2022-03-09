using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxe : MonoBehaviour
{
    public float damage;
    public float rotSpeed;
    public float maxSwing;
    public Transform rotPoint;
    
     
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private float startX;

    void Awake()
    {
        startX = gameObject.transform.position.x;
    }
 
    void FixedUpdate () {
        if(System.Math.Abs(startX - gameObject.transform.position.x) >= maxSwing)
        {
            rotSpeed = -1 * rotSpeed;
        }
        transform.RotateAround(rotPoint.position, zAxis, rotSpeed);
    }

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
