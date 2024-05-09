using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AmmosManager ammoManager;

    public int ammoToAdd = 2;

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

            if (ammoManager.munizioni < ammoManager.ammos.Length)
            {
                Debug.Log("Adding ammo");
                AudioManager.instance.Play("Ricarico");

                ammoManager.munizioni += ammoToAdd;

                if (ammoManager.munizioni > ammoManager.ammos.Length)
                {
                    ammoManager.munizioni = ammoManager.ammos.Length;
                }

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Munizioni al massimo");
            }
        }
    }
}
