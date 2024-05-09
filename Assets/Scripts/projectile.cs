using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;
    private Boss boss;
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
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Boss"))
            {
                boss = other.gameObject.GetComponent<Boss>();
                    if (boss != null)
                {
                    boss.health--;
                }
            }

            PlayDestructionAnimation();

            isMoving = false;

            Destroy(gameObject, 0.75f);
        }
    }

    void PlayDestructionAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Destroy");
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
