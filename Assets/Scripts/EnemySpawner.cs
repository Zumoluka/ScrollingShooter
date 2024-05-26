using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*public GameObject enemyPrefab;  // Prefab del enemigo
    public float spawnRate = 2f;    // Frecuencia de aparición en segundos
    private float nextSpawn = 0f;
    private Vector2 screenBounds;

    void Start()
    {
        // Calcula los límites de la pantalla
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // Genera enemigos a intervalos regulares
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Genera el enemigo en el borde inferior de la pantalla
        float xPosition = Random.Range(-screenBounds.x, screenBounds.x);
        Vector2 spawnPosition = new Vector2(xPosition, screenBounds.y * -1);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }*/
    public GameObject enemyPrefab;   // Prefab del enemigo
    public GameObject powerUpPrefab; // Prefab del power-up
    public float spawnRate = 2f;     // Frecuencia de aparición en segundos
    public float powerUpChance = 0.1f; // Probabilidad de generar un power-up (0-1)
    private float nextSpawn = 0f;
    private Vector2 screenBounds;

    void Start()
    {
        // Calcula los límites de la pantalla
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // Genera enemigos y posiblemente power-ups a intervalos regulares
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            if (Random.value < powerUpChance)
            {
                SpawnPowerUp();
            }
            else
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        // Genera el enemigo en el borde inferior de la pantalla
        float xPosition = Random.Range(-screenBounds.x, screenBounds.x);
        Vector2 spawnPosition = new Vector2(xPosition, screenBounds.y * -1);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnPowerUp()
    {
        // Genera el power-up en una posición verticalmente centrada pero dentro de los límites horizontales de la pantalla
        float xPosition = Random.Range(-screenBounds.x, screenBounds.x);
        float yPosition = Random.Range(-screenBounds.y / 2, screenBounds.y / 2); // Ajusta la altura como desees
        Vector2 spawnPosition = new Vector2(xPosition, yPosition);
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
}
