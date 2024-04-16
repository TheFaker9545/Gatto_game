using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;
    public float lenght = 57.6f;
    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right * lenght;
        if (mainCam.position.x < middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.left * lenght;
        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;
        }

    }
}