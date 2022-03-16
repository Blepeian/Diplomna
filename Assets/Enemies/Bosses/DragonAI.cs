using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAI : MonoBehaviour
{
    public float moveSpeed;
    public enemyState state;
    public Transform playerTransform;
    public Rigidbody2D body;
    public Transform eyes;
    public bool lookingRight;
    public float sightDistance;
    public GameObject bossDoor;

    public Ability rangedAttack;
    public Ability meleeAttack;
    public float projectileRange;
    public float meleeRange;

    private float velocity;
    private RaycastHit2D[] seenObjs;
    
    void Start()
    {
        state = enemyState.Idle;
        body = gameObject.GetComponent<Rigidbody2D>();
        velocity = 0;
        bossDoor.SetActive(false);
        lookingRight = false;
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
                bossDoor.SetActive(true);
                state = enemyState.Attacking;
                gameObject.GetComponent<BossStats>().StartBattle();
            }
        }
        if(state == enemyState.Idle)
        {
            body.velocity = new Vector2(0, 0);
        }
        
        if(state == enemyState.Attacking)
        {
            if(Vector2.Distance(playerTransform.position, transform.position) <= projectileRange)
            {
                velocity = 0;
                if(Vector2.Distance(playerTransform.position, transform.position) <= meleeRange)
                {
                    meleeAttack.Cast();
                }
                else
                {
                    rangedAttack.Cast();
                }
            }
            else if(playerTransform.position.x > transform.position.x)
            {
                velocity = moveSpeed;
            }
            else if(playerTransform.position.x < transform.position.x)
            {
                velocity =  -moveSpeed;
            }

            if(playerTransform.position.x > transform.position.x)
            {
                lookingRight = true;
            }
            else if(playerTransform.position.x < transform.position.x)
            {
                lookingRight = false;
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
