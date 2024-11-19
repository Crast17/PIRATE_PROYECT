using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
     rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

        // Limita el movimiento dentro de los bordes del suelo
        newPosition.x = Mathf.Clamp(newPosition.x, -45f, 45f); // Limita en X (lateral)
        newPosition.z = Mathf.Clamp(newPosition.z, -120f, 0f); // Limita en Z (adelante-atrás)

        rb.MovePosition(newPosition);


    }
}
