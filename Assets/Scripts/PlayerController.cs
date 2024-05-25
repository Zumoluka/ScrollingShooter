using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform projectileSpawnPoint;  // Punto de aparición del proyectil
    public int health = 100;  // Vida del jugador
    public TextMeshProUGUI healthText;  // Texto para mostrar la vida en la interfaz
    public TextMeshProUGUI scoreText;  // Texto para mostrar la puntuación en la interfaz
    public float speed = 5;
    public float padding = 1f;
    private float score = 0f;

    void Start()
    {
        // Inicializar la posición del punto de aparición del proyectil
        Vector2 screenTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, Camera.main.transform.position.z));
        projectileSpawnPoint.position = new Vector2(screenTop.x, screenTop.y);

        // Actualizar la vida y la puntuación en la interfaz
        UpdateHealthText();
        UpdateScoreText();
    }

    void Update()
    {
        // Dispara un proyectil al presionar la tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // Aumenta la puntuación por cada segundo que pasa
        score += Time.deltaTime;
        UpdateScoreText();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement);
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float clampedX = Mathf.Clamp(transform.position.x, -screenWidth + padding, screenWidth - padding);
        float clampedY = Mathf.Clamp(transform.position.y, -Camera.main.orthographicSize + padding, Camera.main.orthographicSize - padding);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void Shoot()
    {
        // Instancia el proyectil en el punto de aparición
        Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Deducir vida al colisionar con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(15);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthText();

        // Verificar si la vida del jugador llega a cero
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
}
