using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform[] backgrounds;  // Arreglo de las capas de fondo
    public float[] parallaxScales;   // Proporci�n del movimiento de la c�mara para mover las capas de fondo
    public float smoothing = 1f;     // Suavizado del movimiento

    private Transform cam;           // Referencia a la c�mara principal
    private Vector3 previousCamPosition;  // Posici�n de la c�mara en el frame anterior

    void Awake()
    {
        // Asigna la c�mara principal
        cam = Camera.main.transform;
    }

    void Start()
    {
        // Guarda la posici�n inicial de la c�mara
        previousCamPosition = cam.position;

        // Asigna las proporciones de parallax para cada capa
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1; // La posici�n Z define la distancia de la c�mara
        }
    }

    void Update()
    {
        // Para cada capa de fondo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calcula el parallax y el objetivo de posici�n
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x - parallax;

            // Crea una posici�n suavizada
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Mueve la capa de fondo hacia la posici�n objetivo
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Guarda la posici�n de la c�mara en este frame
        previousCamPosition = cam.position;
    }
}
