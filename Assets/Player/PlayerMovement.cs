using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int maxJumps;
    public Transform feet;
    public LayerMask terrain;
    public float checkRadius;
    public bool lookingRight = true;
    public float dodgingSpeed;
    public float dodgeCooldown;


    private Rigidbody2D body;
    private float direction;
    private bool jumping = false;
    private int remainingJumps;
    private bool grounded;
    
    private bool dodging;
    private float currDodgeSpeed;
    private float remDodgeCooldown = 0f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps;
        currDodgeSpeed = dodgingSpeed;
    }

    void Update()
    {
        GetInput();

        Animate();

        if(dodging)
        {
            currDodgeSpeed -= currDodgeSpeed * 10f * Time.deltaTime;
            if(currDodgeSpeed < 5f)
            {
                dodging = false;
                gameObject.GetComponent<PlayerStats>().isInvincible = false;
            }
        }

        if(remDodgeCooldown > 0)
        {
            remDodgeCooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(feet.position, checkRadius, terrain);
        if(grounded)
        {
            remainingJumps = maxJumps;
        }

        Move(moveSpeed);

        if(dodging)
        {
            Dodge();
        }
    }

    private void GetInput()
    {
        direction = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && remainingJumps > 0)
        {
            jumping = true;
        }

        if(Input.GetButtonDown("Dodge") && remDodgeCooldown <=0)
        {
            remDodgeCooldown = dodgeCooldown;
            currDodgeSpeed = dodgingSpeed;
            dodging = true;
        }
    }

    private void Animate()
    {
        if(direction > 0 && !lookingRight)
        {
            Flip();
        }
        else if(direction < 0 && lookingRight)
        {
            Flip();
        }
    }

    private void Move(float speed)
    {
        if(!dodging)
        {
            body.velocity = new Vector2(direction * speed, body.velocity.y);

            if(jumping && remainingJumps > 0)
            {
                body.velocity = new Vector2(body.velocity.x, 0);
                body.AddForce(new Vector2(0f, jumpForce));
                remainingJumps--;
            }

            jumping = false;
        }
    }

    private void Flip()
    {
        lookingRight = !lookingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Dodge()
    {
        gameObject.GetComponent<PlayerStats>().isInvincible = true;
        if(lookingRight)
        {
            body.velocity = new Vector2(currDodgeSpeed, body.velocity.y);
        }
        else if(!lookingRight)
        {
            body.velocity = new Vector2(-currDodgeSpeed, body.velocity.y);
        }
    }
}
