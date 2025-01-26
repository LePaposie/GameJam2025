using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Velocidad de movimiento de la cámara
    public Vector2 moveLimitsX = new Vector2(-10, 10); // Límites en el eje X
    public Vector2 moveLimitsZ = new Vector2(-10, 10); // Límites en el eje Z

    [Header("Rotation Settings")]
    public bool allowRotation = true; // Habilitar rotación de la cámara
    public float rotationSpeed = 50f; // Velocidad de rotación

    private Vector2 moveInput; // Entrada de movimiento
    private float rotationInput; // Entrada de rotación

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
        // Convertimos el input de 2D a movimiento en 3D (isométrico)
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        // Aplicamos movimiento
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // Respetamos los límites
        newPosition.x = Mathf.Clamp(newPosition.x, moveLimitsX.x, moveLimitsX.y);
        newPosition.z = Mathf.Clamp(newPosition.z, moveLimitsZ.x, moveLimitsZ.y);

        transform.position = newPosition;
    }  
}
