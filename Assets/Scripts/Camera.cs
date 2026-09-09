using UnityEngine;

public class Camera : MonoBehaviour
{
    // El personaje al que la cámara va a seguir
    public Transform target;

    // Distancia de la cámara 
    public Vector3 offset = new Vector3(0f, 10f, -5f);

    // Velocidad de la camara
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Posición exacta de la camara con respecto al personaje
        Vector3 desiredPosition = target.position + offset;

        // Movimiento de la posición actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
