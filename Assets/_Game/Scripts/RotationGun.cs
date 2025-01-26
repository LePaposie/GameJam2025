using UnityEngine;

public class RotationGun : MonoBehaviour
{
    public float velocidadRotacion = 100f; // Velocidad de rotación
    public float limiteIzquierda = -45f;  // Límite de rotación a la izquierda
    public float limiteDerecha = 45f;     // Límite de rotación a la derecha

    private float rotacionActual = -90f;  // La rotación inicial de la torreta (en grados)

    void Start()
    {
        // Aseguramos que la torreta empiece en -90 grados
        transform.rotation = Quaternion.Euler(0, rotacionActual, 0);
    }

    void Update()
    {
        // Obtener el input del teclado y del mando para rotar
        float inputRotacion = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Flecha izquierda o A
        {
            inputRotacion = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Flecha derecha o D
        {
            inputRotacion = 1f;
        }

        // Si usas un mando, también puedes capturar la rotación de los ejes
        inputRotacion += Input.GetAxis("Horizontal");  // "Horizontal" es un eje predeterminado de Unity para el mando

        // Actualizar la rotación actual con la entrada
        rotacionActual += inputRotacion * velocidadRotacion * Time.deltaTime;

        // Asegurarse de que la rotación esté dentro de los límites establecidos
        rotacionActual = Mathf.Clamp(rotacionActual, limiteIzquierda, limiteDerecha);

        // Aplicar la rotación de la torreta
        transform.rotation = Quaternion.Euler(0, rotacionActual, 0);
    }
}