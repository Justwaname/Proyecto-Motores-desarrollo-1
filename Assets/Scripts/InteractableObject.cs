using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //Función que se  ejecuta cuando el jugador interactua con el objeto
    public void Interact()
    {
        // si anda el scrip
        Debug.Log(" se interactua con el item.");

       
    {
      
        {
           
            Debug.Log("Objeto recogido: " + gameObject.name);

            // Destruye el objeto del mapa
            Destroy(gameObject);
        }
    }
}
}