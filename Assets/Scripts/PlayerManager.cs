using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isWin;
    public static bool isBoss;
    public static bool boss;
    public GameObject gameOverScreen;
    public GameObject endScreen;
    public GameObject PauseScreen;
    private GameObject player;
    public GameObject BossBar;
    public GameObject Boss;
    public GameObject winFlag;

    private void Awake()
    {
        isWin = false;
        isGameOver = false;
        isBoss = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        isGameOver = false;
        isBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        if(isWin)
        {
            endScreen.SetActive(true);
        }
        if(isBoss)
        {
            BossBar.SetActive(true);
            Boss.SetActive(true);
            winFlag.SetActive(false);
        }
        if(isBoss == false){
            BossBar.SetActive(false);
            Boss.SetActive(false);    
            winFlag.SetActive(true);  
        }
    }
        public void BossDefeated()
    {
        winFlag.SetActive(true);
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Menù");
        AudioManager.instance.Stop("Livello1");
        Start();
    }
      public void RestartLevel()
    {
        SceneManager.LoadScene("Livello1");
        Start();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        player.gameObject.SetActive(false);
    }
    public void resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        player.gameObject.SetActive(true);
    }
}
