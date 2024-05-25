using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab del enemigo
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
    }
}
