using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void play(int index)
    {
    SceneManager.LoadScene(index);
    }

}
