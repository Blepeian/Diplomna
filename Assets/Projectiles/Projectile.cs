using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpriteDirection{
        Right,
        Up,
        Down,
        Left
    }


public class Projectile : MonoBehaviour
{
    public float damage;
    public string projectileName;
    public float flightSpeed;
    public Rigidbody2D body;
    public SpriteDirection spriteDirection;
    public Vector2 flightDirection;

    private float speedX = 0;
    private float speedY = 0;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.gameObject.tag == "Player")
        {
            col.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void CheckDirection()
    {
        if(spriteDirection == SpriteDirection.Up)
        {
            transform.Rotate(0f, 0f, 90f, Space.Self);
            flightDirection = new Vector2(0, 1);
            speedY = flightSpeed;

        }
        else if(spriteDirection == SpriteDirection.Down)
        {
            transform.Rotate(0f, 0f, -90f, Space.Self);
            flightDirection = new Vector2(0, -1);
            speedY = flightSpeed;
        }
        else if(spriteDirection == SpriteDirection.Left)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
            flightDirection = new Vector2(-1, 0);
            speedX = flightSpeed;
        }
        else
        {
            flightDirection = new Vector2(1, 0);
            speedX = flightSpeed;
        }
    }

    public void MoveProjectile()
    {
        body.velocity = new Vector2(flightDirection.x * speedX, flightDirection.y * speedY);
    }
}
