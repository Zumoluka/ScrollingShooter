using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform[] backgrounds;  // Arreglo de las capas de fondo
    public float[] parallaxScales;   // Proporción del movimiento de la cámara para mover las capas de fondo
    public float smoothing = 1f;     // Suavizado del movimiento

    private Transform cam;           // Referencia a la cámara principal
    private Vector3 previousCamPosition;  // Posición de la cámara en el frame anterior

    void Awake()
    {
        // Asigna la cámara principal
        cam = Camera.main.transform;
    }

    void Start()
    {
        // Guarda la posición inicial de la cámara
        previousCamPosition = cam.position;

        // Asigna las proporciones de parallax para cada capa
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1; // La posición Z define la distancia de la cámara
        }
    }

    void Update()
    {
        // Para cada capa de fondo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calcula el parallax y el objetivo de posición
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x - parallax;

            // Crea una posición suavizada
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Mueve la capa de fondo hacia la posición objetivo
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Guarda la posición de la cámara en este frame
        previousCamPosition = cam.position;
    }
}
