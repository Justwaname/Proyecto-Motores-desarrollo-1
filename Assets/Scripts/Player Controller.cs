using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private PlayerInput playerInput;
    private Vector2 inputWalk;
    private float inputSprint;

    [SerializeField] float currentSpeed;
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float runSpeed = 20f;
    [SerializeField] float stamina = 7f;
    [SerializeField] float timeStoppedRuning = 7f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        inputWalk = playerInput.actions["Move"].ReadValue<Vector2>();
        inputSprint = playerInput.actions["Sprint"].ReadValue<float>();
        Debug.Log(inputWalk);
        Debug.Log(inputSprint);

        if (inputSprint != 0)
        {
            currentSpeed = runSpeed;
            stamina -= 1 * Time.deltaTime;
            timeStoppedRuning -= 1 * Time.deltaTime;
        } else if (inputSprint == 0) { currentSpeed = walkSpeed; }
        if (timeStoppedRuning < 7 && inputSprint == 0)
        { timeStoppedRuning += 1 * Time.deltaTime; }
        if(stamina < 7 && timeStoppedRuning >= 7)
        { stamina += 1.5f * Time.deltaTime; }
    }
    private void FixedUpdate()
    {
        rigidbody.linearVelocity = new Vector3(inputWalk.normalized.x * currentSpeed, 0, inputWalk.normalized.y * currentSpeed);  
    }
}
