using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInteraction : MonoBehaviour
{
    // Le asignamos la tecla 'E' 
    // Se puede modificar desde el Inspector de Unity
    public InputAction interactAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/e");

    private InteractableObject objectToInteract; // Guarda el item con el que podemos interactuar

    // En el New Input System, las acciones deben habilitarse y deshabilitarse
    private void OnEnable()
    {
        interactAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }

    void Update()
    {
        if (interactAction.WasPressedThisFrame() && objectToInteract != null)
        {
            objectToInteract.Interact();
        }
    }

    // collider de "Trigger"
    private void OnTriggerEnter(Collider other)
    {
        // el objeto tiene que tener el tag "Interactable" para poder interactuar con él
        if (other.CompareTag("Interactable"))
        {
            objectToInteract = other.GetComponent<InteractableObject>();
        }
    }

    // Se activa cuando nos alejamos del item con el que podemos interactuar
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // se vacia la variable porque ya no estamos cerca
            objectToInteract = null;
        }
    }
}