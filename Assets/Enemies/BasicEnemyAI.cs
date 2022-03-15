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
    public Transform playerTransform;
    public float attackRange;
    public Rigidbody2D body;
    public float maxFollowDistance;
    public bool returning = false;
    public Transform eyes;
    public bool lookingRight = true;

    public Ability enemyAttack;

    private float sightDistance;
    private float velocity;
    [SerializeField] private Vector2 start;
    private RaycastHit2D[] seenObjs;
    
    void Start()
    {
        start = transform.position;
        state = enemyState.Idle;
        body = gameObject.GetComponent<Rigidbody2D>();
        velocity = -moveSpeed;
        sightDistance = attackRange * 2;
    }

    void Update()
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }

        ControlEnemy();
    }

    private void ControlEnemy()
    {
        if(lookingRight)
        {
            seenObjs = Physics2D.RaycastAll(eyes.position, Vector2.right, sightDistance);
        }
        else
        {
            seenObjs = Physics2D.RaycastAll(eyes.position, Vector2.left, sightDistance);
        }

        foreach(RaycastHit2D obj in seenObjs)
        {
            if(obj.collider.gameObject.tag == "Player")
            {
                state = enemyState.Attacking;
            }
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
            if(Vector2.Distance(playerTransform.position, transform.position) <= maxFollowDistance)
            {
                if(Vector2.Distance(playerTransform.position, transform.position) <= attackRange)
                {
                    velocity = 0;
                    enemyAttack.Cast();
                }
                else if(playerTransform.position.x > transform.position.x)
                {
                    velocity = moveSpeed;
                    lookingRight = true;
                }
                else if(playerTransform.position.x < transform.position.x)
                {
                    velocity =  -moveSpeed;
                    lookingRight = false;
                }
            }
            else if(Vector2.Distance(playerTransform.position, transform.position) > maxFollowDistance)
            {
                transform.position = start;
                state = enemyState.Idle;
            }


            body.velocity = new Vector2(velocity, body.velocity.y);
        }

        if(lookingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
