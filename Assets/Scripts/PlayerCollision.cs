using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = false;
            HealthManager.health--;
            if(HealthManager.health <= 0){
                PlayerManager.isGameOver = true;
                Debug.Log("colpito");
            } else {
                StartCoroutine(GetHurt());
            }
           
        }
    }
    IEnumerator GetHurt(){
        Physics2D.IgnoreLayerCollision(8,9);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(8,9, false);
    }
}
