using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Riferimento a un'istanza di HealthManager
    public HealthManager healthManagerInstance;

    public int healthToAdd = 1;

    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;

        // Assegna l'istanza di HealthManager
        healthManagerInstance = FindObjectOfType<HealthManager>();
        if (healthManagerInstance == null)
        {
            Debug.LogError("HealthManager non trovato nellla scena!");
        }
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
            // Controlla se l'istanza di HealthManager è valida
            if (healthManagerInstance != null)
            {
                // Accedi alla variabile hearts tramite l'istanza di HealthManager
                if (HealthManager.health < healthManagerInstance.hearts.Length)
                {
                    Debug.Log("Adding health");

                    HealthManager.health += healthToAdd;

                    if (HealthManager.health > healthManagerInstance.hearts.Length)
                    {
                        HealthManager.health = healthManagerInstance.hearts.Length;
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
}

