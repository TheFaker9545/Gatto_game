using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;
    
    public GameObject PauseScreen;
    private void awake()
    {
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Menù");
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
    }
    public void resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }
}
