using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    private float screenBottom;

    void Start()
    {
        // Calcula el límite inferior de la pantalla
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z)).y;
        // Mueve el proyectil hacia abajo
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
    }

    void Update()
    {
        // Destruye el proyectil si sale de la parte inferior de la pantalla
        if (transform.position.y < screenBottom)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruye el proyectil y el enemigo al colisionar
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
