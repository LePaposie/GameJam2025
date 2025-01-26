using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerDef : MonoBehaviour
{
    public Vector3 direction;
    public Rigidbody rb;


    [Header("Movement Settings")]
    public float moveSpeed = 10f; // Velocidad de movimiento de la cámara

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(direction * moveSpeed, ForceMode.Force);
    }

    public void Movement(InputAction.CallbackContext ctx) 
    {
        if (ctx.performed)
        {
            var dir = ctx.ReadValue<Vector2>();
            direction.x = dir.x;
            direction.z = dir.y;
        }
        else
        {
            direction = Vector3.zero;
        }
    }
}
