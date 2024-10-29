using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float fallSpeed = 2f;

    private void Update() {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyPowerUp();

            Destroy(gameObject);
        }
        else if (collision.CompareTag("LoseZone"))
        {
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp() {
         switch (powerUpType)
        {
            case PowerUpType.ExpandlePlayer:
                GameManager.instance.ExpandlePlayer();
                break;

            case PowerUpType.DuplicateBall:
                GameManager.instance.DuplicateBall();
                break;
        }
    }
}
