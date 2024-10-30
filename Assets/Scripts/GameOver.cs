using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour

{
    public int playerHealth = 3; // Vida inicial del jugador
    public GameObject gameOverCanvas; // Asigna el GameOverCanvas desde el inspector

    private void Start()
    {
        gameOverCanvas.SetActive(false); // Asegúrate de que el canvas esté desactivado al inicio
    }

    // Método para reducir la vida del jugador
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            GameOverk();
        }
    }

    private void GameOverk()
    {
       // gameOverCanvas.SetActive(true); 
        Time.timeScale = 0f;
    }

    // Método para reiniciar el juego (si tienes un botón de reinicio en el canvas)
    public void RestartGame()
    {
        Time.timeScale = 1f; // Restablece el tiempo normal
    }
}


