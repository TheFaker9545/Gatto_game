using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTheme : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Rigidbody2D rb;
    private bool bossMusicPlaying = false;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !bossMusicPlaying)
        {
            bossMusicPlaying = true;
            StartCoroutine(FadeOutAndPlayBossTheme());
            PlayerManager.isBoss = true;

        }
    }

    IEnumerator FadeOutAndPlayBossTheme()
    {
        AudioManager.instance.FadeOut("Livello1", 2f);

        yield return new WaitForSeconds(2f);

        AudioManager.instance.Play("BossTheme");
    }
}
