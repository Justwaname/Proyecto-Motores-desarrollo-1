using UnityEngine;
using UnityEngine.InputSystem;

public class SphereCastInteractor : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactRadius = 0.5f;
    public float interactDistance = 3.0f;

    // LayerMask para comprobar Tags para físicas
    public LayerMask interactableLayer;

    [Header("Input Settings")]
    public InputActionReference interactActionReference;

    void OnEnable()
    {
        if (interactActionReference != null)
        {
            interactActionReference.action.Enable();
            interactActionReference.action.performed += OnInteractPerformed;
            Debug.Log("SphereCastInteractor: Input Enabled.");
        }
        else
        {
            Debug.LogWarning("SphereCastInteractor: Input Action Reference is missing!");
        }
    }

    void OnDisable()
    {
        if (interactActionReference != null)
        {
            interactActionReference.action.performed -= OnInteractPerformed;
            interactActionReference.action.Disable();
            Debug.Log("SphereCastInteractor: Input Disabled.");
        }
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Interaction input detected. Searching for objects...");
        TryInteract();
    }

    private void TryInteract()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hitInfo;

        // SphereCast buscando solo en la capa de interactuables
        bool hasHit = Physics.SphereCast(origin, interactRadius, direction, out hitInfo, interactDistance, interactableLayer);

        if (hasHit)
        {
            // Script de interacción del objeto golpeado
            InteractableObject interactable = hitInfo.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                Debug.Log("SUCCESS: Interactable object found -> " + hitInfo.collider.gameObject.name);

                // Ejecutamos la función de interacción
                interactable.Interact();
            }
            else
            {
                Debug.Log("INFO: Object found, but it does not have an InteractableObject component.");
            }
        }
        else
        {
            Debug.Log("MISS: No interactable objects in range.");
        }
    }

    // OnDrawGizmosSelected para que solo se dibuje cuando seleccionas el objeto en Unity
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactRadius);

        Vector3 endPosition = transform.position + (transform.forward * interactDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(endPosition, interactRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, endPosition);
    }
}
