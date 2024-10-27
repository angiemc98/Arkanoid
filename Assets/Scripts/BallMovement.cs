using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float InitSpeed = 10f;
    private Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        ball.velocity = direction * InitSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        ball.velocity = ball.velocity.normalized * InitSpeed;

        if (collision.gameObject.CompareTag("LoseZone"))
        {
            GameManager.instance.Loselife();
        }
        
    }

}
