using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitar : MonoBehaviour
{
    public float amplitude = 0.5f;  // Amplitud del movimiento (altura máxima de subida y bajada)
    public float speed = 1.0f;      // Velocidad del movimiento

    private Vector3 startPosition; // Posición inicial del objeto
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        // Aplicar el nuevo movimiento al objeto
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
