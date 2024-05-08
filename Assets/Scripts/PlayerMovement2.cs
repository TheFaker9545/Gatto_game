using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
    float direction = 0;
    public Rigidbody2D rb;
    public AmmosManager ammoManager;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    bool isJumping = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Awake()
    {
        controls = new PlayerControl();
        controls.Enable();

        controls.Land.Jump.performed += ctx => OnJump();
        controls.Land.Shoot.performed += ctx => OnShoot();

        shootTimer = shootDelay;
    }

    void Update()
    {
        horizontal = controls.Land.Move.ReadValue<float>();
        shootTimer -= Time.deltaTime;

        Flip();
    }

    void OnJump()
{
    if (IsGrounded())
    {
        AudioManager.instance.Play("Salto");
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        isJumping = true;
        animator.SetBool("IsJumping", isJumping);
        }
}

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.x);
    }

    void Flip()
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

    void OnShoot()
    {
        if (shootTimer <= 0f && ammoManager.munizioni > 0)
        {
            AudioManager.instance.Play("Sparo");            
            Vector3 offset = isFacingRight ? Vector3.right * offsetDistance : Vector3.left * offsetDistance;
            GameObject projectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);

            Vector3 playerDirection = isFacingRight ? Vector3.right : Vector3.left;
            projectile.GetComponent<Projectile>().SetDirection(playerDirection);

            SpriteRenderer projectileRenderer = projectile.GetComponent<SpriteRenderer>();
            projectileRenderer.flipX = !isFacingRight;

            ammoManager.munizioni--;

            shootTimer = shootDelay;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", isJumping);
        }
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}