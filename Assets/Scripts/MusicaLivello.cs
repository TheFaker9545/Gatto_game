using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaLivello : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Livello1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
