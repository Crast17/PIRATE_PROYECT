using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // Velocidad de movimiento

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime); // Mover hacia atrás
        if (transform.position.z < -100f) // Destruir si salen del terreno

        {
            Destroy(gameObject);
        }

    }
}
