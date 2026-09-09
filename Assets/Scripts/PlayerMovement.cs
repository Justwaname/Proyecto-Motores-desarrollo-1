using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    // velocidad del personaje 
    public float speed = 5f;

    // acción de movimiento
    public InputAction moveAction;

    private void Awake()
    {
        moveAction = new InputAction("Move");

        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}