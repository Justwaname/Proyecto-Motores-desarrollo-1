using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    private InteractableObject objectToInteract; // Guarda el item con el que podemos interactuar

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && objectToInteract != null)
        {
            objectToInteract.Interact();
        }
    }

    // Se activa automáticamente cuando el jugador choca con un "Trigger"
    private void OnTriggerEnter(Collider other)
    {
        // el objeto tiene que tener el tag "Interactable" para poder interactuar con él
        if (other.CompareTag("Interactable"))
        {
            // se guarda el objeto para poder interactuar con él
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
