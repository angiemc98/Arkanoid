using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public Transform player;
    public Transform ball;

    private Vector2 playerStartPos;
    private Vector2 ballStartPos;
    public static GameManager instance; // Singleton para acceder desde otros scripts


    private void Start()
    {
        playerStartPos = player.position;
        ballStartPos = ball.position;
    }
    private void Awake()
    {
        // Configurar GameManager como Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Para mantener el GameManager al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Loselife()
    {
        lives--;
        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            ResetPosition();
        }
    }

    
    public void ResetPosition()
    {
        player.position = playerStartPos;
        ball.position = ballStartPos;
        ball.GetComponent<BallMovement>().LaunchBall();
    }

}
