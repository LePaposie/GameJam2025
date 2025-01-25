using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Velocidad de movimiento de la c�mara
    public Vector2 moveLimitsX = new Vector2(-10, 10); // L�mites en el eje X
    public Vector2 moveLimitsZ = new Vector2(-10, 10); // L�mites en el eje Z

    [Header("Rotation Settings")]
    public bool allowRotation = true; // Habilitar rotaci�n de la c�mara
    public float rotationSpeed = 50f; // Velocidad de rotaci�n

    private Vector2 moveInput; // Entrada de movimiento
    private float rotationInput; // Entrada de rotaci�n

    private void Update()
    {
        HandleMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Capturamos la entrada de movimiento
        moveInput = context.ReadValue<Vector2>();
    }


    private void HandleMovement()
    {
        // Convertimos el input de 2D a movimiento en 3D (isom�trico)
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        // Aplicamos movimiento
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // Respetamos los l�mites
        newPosition.x = Mathf.Clamp(newPosition.x, moveLimitsX.x, moveLimitsX.y);
        newPosition.z = Mathf.Clamp(newPosition.z, moveLimitsZ.x, moveLimitsZ.y);

        transform.position = newPosition;
    }  
}
