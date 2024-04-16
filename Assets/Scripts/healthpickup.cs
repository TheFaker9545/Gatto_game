using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthManager healthManager;

    public int healthToAdd = 1;

    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            if (healthManager.health < healthManager.hearts.Length)
            {
                Debug.Log("Adding ammo");

                healthManager.health += healthToAdd;

                if (healthManager.health > healthManager.hearts.Length)
                {
                    healthManager.health = healthManager.hearts.Length;
                }

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Salute al massimo");
            }
        }
    }
}
