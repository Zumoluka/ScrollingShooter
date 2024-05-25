using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del enemigo
    private Vector2 screenBounds;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, speed);
        // Calcula los límites de la pantalla
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // Rebotar en los bordes de la pantalla
        if (transform.position.x < screenBounds.x * -1 || transform.position.x > screenBounds.x)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

        // Destruir el enemigo si sale por la parte superior de la pantalla
        if (transform.position.y > screenBounds.y)
        {
            Destroy(gameObject);
        }
    }

}
