using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float cooldown;
    public SpriteDirection projDirection;

    private float currCooldown;

    private void Start()
    {
        currCooldown = cooldown;
    }

    private void Update()
    {
        currCooldown -= Time.deltaTime;

        if(currCooldown <= 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject  projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectileObj.GetComponent<Projectile>().spriteDirection = projDirection;
        projectileObj.GetComponent<Projectile>().CheckDirection();
        projectileObj.GetComponent<Projectile>().MoveProjectile();

        currCooldown = cooldown;
    }
}
