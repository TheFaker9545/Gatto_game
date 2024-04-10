using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmosManager : MonoBehaviour
{
    public int munizioni = 3;

    public Image[] ammos;
    public Sprite Proiettilepieno;
    public Sprite Proiettilevuoto;

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in ammos)
        {
            img.sprite = Proiettilevuoto;
        }
        for (int i = 0; i < munizioni; i++)
        {
            ammos[i].sprite = Proiettilepieno;
        }
    }
}
