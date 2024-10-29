using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
     public float InitSpeed = 10f;
    public Rigidbody2D ball;

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
        // Mantener la velocidad constante después de cada colisión
        ball.velocity = ball.velocity.normalized * InitSpeed;

        // Verificar si colisiona con la DeadZone
        if (collision.gameObject.CompareTag("LoseZone"))
        {
            // Llamar a la función LoseLife del GameManager
           GameManager.instance.Loselife();
        }
    }

    public void ResetBallPosition()
    {
        // Restablece la posición de la pelota al inicio, por ejemplo (0, 0)
        transform.position = Vector3.zero;
        // Reinicia la velocidad de la pelota
        LaunchBall();
    }

}
