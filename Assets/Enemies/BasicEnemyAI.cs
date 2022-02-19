using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState{
    Idle, 
    Attacking
}

public class BasicEnemyAI : MonoBehaviour
{
    public float moveSpeed;
    public enemyState state;
    public float moveDistance;
    public GameObject player;
    public float attackRange;
    public Rigidbody2D body;
    public float maxFollowDistance;
    public bool returning = false;

    private float sightDistance;
    private bool lookingRight = true;
    private float velocity;
    [SerializeField] private Vector2 start;
    private LayerMask playerLayer;
    
    void Start()
    {
        start = transform.position;
        state = enemyState.Idle;
        player = GameObject.Find("Player");
        body = gameObject.GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.GetMask("Player");
        velocity = -moveSpeed;
        sightDistance = attackRange * 2;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= sightDistance)
        {
            state = enemyState.Attacking;
        }

        if(state == enemyState.Idle)
        {
            if(Vector2.Distance(start, transform.position) >= moveDistance)
            {
                if(!lookingRight)
                {
                    velocity = moveSpeed;
                }
                else if(lookingRight)
                {
                    velocity =  -moveSpeed;
                }

                transform.Rotate(0f, 180f, 0f);
                lookingRight = !lookingRight;
            }
            body.velocity = new Vector2(velocity, body.velocity.y);
        }
        
        if(state == enemyState.Attacking)
        {
            if(Vector2.Distance(player.transform.position, transform.position) <= maxFollowDistance)
            {
                if(Vector2.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    velocity = 0;
                }
                else if(player.transform.position.x > transform.position.x)
                {
                    velocity = moveSpeed;
                    lookingRight = true;
                }
                else if(player.transform.position.x < transform.position.x)
                {
                    velocity =  -moveSpeed;
                    lookingRight = false;
                }
            }
            else if(Vector2.Distance(player.transform.position, transform.position) > maxFollowDistance)
            {
                transform.position = start;
                state = enemyState.Idle;
            }

            if(velocity > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if(velocity < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            body.velocity = new Vector2(velocity, body.velocity.y);
        }
    }
}
