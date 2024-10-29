using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int totalBlocks;
    public Transform player;
    public Transform ball;
    public GameObject playerPaddle;
    public GameObject ballPrefab;


    private Vector2 playerStartPos;
    private Vector2 ballStartPos;
    private Vector3 playerScale;
    public TextMeshProUGUI scoreText; // Referencia al texto del HUD usando TextMeshProUGUI
    private int totalScore = 0;
    public static GameManager instance; // Singleton para acceder desde otros scripts


    private void Start()
    {
        playerStartPos = player.position;
        ballStartPos = ball.position;
        playerScale = player.transform.localScale;
        totalBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
        UpdateScoreText(); // Inicializa el puntaje en el HUD
        SceneManager.sceneLoaded += OnSceneLoaded;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        updateBlockCount();
        UpdateScoreText();
    }

    private void updateBlockCount()
    {
        totalBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
    }

     public void AddScore(int points)
    {
        // Añadir puntos al total y actualizar el HUD
        totalScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Actualizar el texto del HUD con el puntaje actual
        scoreText.text = "Score: " + totalScore;
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

    public void ExpandlePlayer()
    {
        player.transform.localScale = new Vector3(playerScale.x * 1.5f, playerScale.y, playerScale.z);
        Invoke("ResetPlayerSize", 5f);
    }

    private void ResetPlayerSize()
    {
        player.transform.localScale = playerScale;
    }

    public void DuplicateBall()
    {
        // Instancia una nueva bola en la posición de la bola original
        GameObject newBall = Instantiate(ballPrefab, ball.position, Quaternion.identity);
        
        // Configura la velocidad inicial de la nueva bola
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * 10f; 
    }

      public void CheckBlocksRemaining()
    {
        totalBlocks--;

        if (totalBlocks <= 0)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // Carga la siguiente escena en el índice de construcción
    }

    private void  OnDestroy() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;   
    }

}
