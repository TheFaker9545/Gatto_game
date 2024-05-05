using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;
    private Vector3 startPos;
    private GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
                AudioManager.instance.Stop("Livello1");
                AudioManager.instance.Play("Win");
                PlayerManager.isWin = true;
                player.gameObject.SetActive(false);
            }
        }
}
