using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughBlock : MonoBehaviour
{
   public int dataPoints = 2;
   public int scoreValue = 20;

   private void OnCollisionEnter2D(Collision2D collision) 
   {
        if (collision.gameObject.CompareTag("Ball"))
        {
            dataPoints--;
            if (dataPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
   }
}
