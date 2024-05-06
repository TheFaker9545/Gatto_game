using UnityEngine;
using UnityEngine.UI;

public class Monete : MonoBehaviour
{
    public GameObject moneteDisplay; // Riferimento al GameObject che contiene il testo
    public static int moneteCollected = 0; // Contatore delle monete raccolte

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moneteCollected++;
            Destroy(gameObject); // Distruggi la moneta una volta raccolta
        }
    }

    private void UpdateMoneteDisplay()
{
    Text textMesh = moneteDisplay.GetComponent<Text>();
    if (textMesh != null)
    {
        textMesh.text = "Coins: " + moneteCollected.ToString();
    }
    else
    {
        Debug.LogError("Il riferimento al GameObject 'moneteDisplay' non è stato assegnato o il GameObject non contiene un componente Text.");
    }
}
    // Chiamato dopo che tutte le collisioni sono state risolte
    private void LateUpdate()
    {
        UpdateMoneteDisplay();
    }
}