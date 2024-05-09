using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private PlayerManager playerManager;
    public int health;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position,player.transform.position);
        if(distance < 35){
            timer += Time.deltaTime;
            if(timer > 0.5){
                timer = 0;
                shoot();
            }
        }
        healthBar.value = health;

        if(health <= 0 ){
            PlayerManager.isBoss = false;
            playerManager.winFlag.SetActive(true);
            playerManager.BossDefeated();

        }
    }

    void shoot(){
        Instantiate(bullet,bulletPos.position, Quaternion.identity);
    }
}