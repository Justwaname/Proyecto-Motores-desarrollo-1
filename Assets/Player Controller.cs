using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private PlayerInput playerInput;
    private Vector2 input;

    public float walkSpeed = 10f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(input);
    }
    private void FixedUpdate()
    {
        rigidbody.linearVelocity = new Vector3(input.normalized.x * walkSpeed, 0, input.normalized.y * walkSpeed);  
    }
}
