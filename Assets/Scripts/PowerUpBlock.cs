using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour
{
   public GameObject powerUpPrefab;
   public int scoreValue = 15;

   private void OnCollisionEnter2D (Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Ball"))
    {
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   }
}
