using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;
    public float length = 83.666996f;
    void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right * length;
        if (mainCam.position.x < middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.left * length;
        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;
        }

    }
}