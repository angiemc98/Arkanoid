using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBasic : MonoBehaviour
{
    // Start is called before the first frame update
  public int scoreValue = 10;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
        GameManager.instance.AddScore(scoreValue);
        Destroy(gameObject);
        GameManager.instance.CheckBlocksRemaining();
    }
  }
  
  
  
  }
