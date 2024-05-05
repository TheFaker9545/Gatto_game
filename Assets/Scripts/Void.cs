using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            HealthManager.health = 0;
            if(HealthManager.health<=0){
                PlayerManager.isGameOver = true;
                AudioManager.instance.Stop("Livello1");
                AudioManager.instance.Play("GameOver");
                player.gameObject.SetActive(false);

            }
        }
    }
}
