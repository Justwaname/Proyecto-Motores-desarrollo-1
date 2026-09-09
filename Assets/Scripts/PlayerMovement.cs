using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // velocidad del perosnaje 
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}