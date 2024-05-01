using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;
    private bool isMoving = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            // Check if the collision is with an object tagged as "Enemy"
            if (other.gameObject.CompareTag("Enemy"))
            {
                // Destroy the enemy
                Destroy(other.gameObject);
            }

            PlayDestructionAnimation();

            isMoving = false;

            Destroy(gameObject, 0.75f);
        }
    }

    void PlayDestructionAnimation()
    {
        // Trigger the "Destroy" animation in the Animator component
        if (animator != null)
        {
            animator.SetTrigger("Destroy");
        }
    }

    void OnBecameInvisible()
    {
        // Destroy the projectile if it becomes invisible
        Destroy(gameObject);
    }
}
