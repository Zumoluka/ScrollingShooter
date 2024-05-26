using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnPoint : MonoBehaviour
{
    private Transform playerTransform;  // Referencia al transform del jugador

    void Start()
    {
        // Obtener la referencia al transform del jugador
        playerTransform = transform.parent;
    }

    void Update()
    {
        // Mantener la posición del proyectil en la misma que la del jugador
        transform.position = playerTransform.position;
    }
}
