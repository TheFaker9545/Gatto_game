using UnityEngine;

public class Monete : MonoBehaviour
{
    public GameObject moneteDisplay; // Riferimento al GameObject che contiene il testo
    private int moneteCollected = 0; // Contatore delle monete raccolte

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moneteCollected++;
            Destroy(gameObject);

            // Aggiorna il testo del GameObject con il nuovo conteggio di monete
            if (moneteDisplay != null)
            {
                TextMesh textMesh = moneteDisplay.GetComponent<TextMesh>();
                if (textMesh != null)
                {
                    textMesh.text = "Monete: " + moneteCollected.ToString();
                }
                else
                {
                    Debug.LogError("Il GameObject 'moneteDisplay' non contiene un componente TextMesh.");
                }
            }
            else
            {
                Debug.LogError("Il riferimento al GameObject 'moneteDisplay' non è stato assegnato.");
            }
        }
    }
}
