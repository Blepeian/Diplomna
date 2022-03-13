using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform target;
    public float cooldown;
    public SpriteDirection projDirection;

    private float currCooldown;
    private Vector3 targetWorldPosition;

    private void Start()
    {
        currCooldown = cooldown;
        targetWorldPosition = target.TransformPoint(transform.position);
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
        GameObject projectileObj;

        if(targetWorldPosition.x > transform.position.x)
        {
            projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileObj.GetComponent<Projectile>().spriteDirection = projDirection;
            projectileObj.GetComponent<Projectile>().CheckDirection();
            projectileObj.GetComponent<Projectile>().MoveProjectile();
        }
        else if(targetWorldPosition.x < transform.position.x)
        {
            projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileObj.GetComponent<Projectile>().spriteDirection = projDirection;
            projectileObj.GetComponent<Projectile>().CheckDirection();
            projectileObj.GetComponent<Projectile>().MoveProjectile();
        }
        else if(targetWorldPosition.y > transform.position.y)
        {
            projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileObj.GetComponent<Projectile>().spriteDirection = projDirection;
            projectileObj.GetComponent<Projectile>().CheckDirection();
            projectileObj.GetComponent<Projectile>().MoveProjectile();
        }
        else if(targetWorldPosition.y < transform.position.y)
        {
            projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileObj.GetComponent<Projectile>().spriteDirection = projDirection;
            projectileObj.GetComponent<Projectile>().CheckDirection();
            projectileObj.GetComponent<Projectile>().MoveProjectile();
        }

        currCooldown = cooldown;
    }
}
