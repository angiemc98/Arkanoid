using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour
{
   public int scoreValue = 15;
   public GameObject powerUpPrefab;
  

   private void OnCollisionEnter2D (Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Ball"))
    {
        GameManager.instance.AddScore(scoreValue);
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.instance.CheckBlocksRemaining();
    }
   }
}
