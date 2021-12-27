using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int maxJumps;
    public Transform head;
    public Transform feet;
    public LayerMask terrain;
    public float checkRadius;


    private Rigidbody2D body;
    private bool lookingRight = true;
    private float direction;
    private bool jumping = false;
    private int remainingJumps;
    public bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        remainingJumps = maxJumps;
    }

    void Update()
    {
        GetInput();

        Animate();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(feet.position, checkRadius, terrain);
        if(grounded)
        {
            remainingJumps = maxJumps;
        }

        Move(moveSpeed);
    }

    private void GetInput()
    {
        direction = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && remainingJumps > 0)
        {
            jumping = true;
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
        body.velocity = new Vector2(direction * speed, body.velocity.y);

        if(jumping && remainingJumps > 0)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(new Vector2(0f, jumpForce));
            remainingJumps--;
        }

        jumping = false;
    }

    private void Flip()
    {
        lookingRight = !lookingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
