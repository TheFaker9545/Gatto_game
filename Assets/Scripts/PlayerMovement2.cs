using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    PlayerControl controls;

public GameObject projectilePrefab;
    public float offsetDistance = 2.0f;
    private float horizontal;
    private float speed = 14f;
    private float jumpingPower = 40f;
    private bool isFacingRight = true;
    public float shootDelay = 0.5f;
    private float shootTimer = 0f;
    int numberOfJumps = 0;
    bool isGrounded;
    float direction = 0;
    public Rigidbody2D rb;


    public AmmosManager ammoManager;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f && Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
            shootTimer = shootDelay;
        }

        Flip();
    }

    private void Awake()
    {
        controls = new PlayerControl();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Shoot()
    {   
        
        if (ammoManager.munizioni > 0)
        {
            Vector3 offset = isFacingRight ? Vector3.right * offsetDistance : Vector3.left * offsetDistance;
            GameObject projectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);

            Vector3 playerDirection = isFacingRight ? Vector3.right : Vector3.left;
            projectile.GetComponent<Projectile>().SetDirection(playerDirection);

            SpriteRenderer projectileRenderer = projectile.GetComponent<SpriteRenderer>();
            projectileRenderer.flipX = !isFacingRight;

            ammoManager.munizioni--;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            numberOfJumps++;
        }
        else
        {
            if(numberOfJumps == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                numberOfJumps++;
            }
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}

