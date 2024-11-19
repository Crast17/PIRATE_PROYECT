using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;           // Velocidad de la bala
    private Vector3 direction;
    public GameObject player;

    void Start()
    {

        if (player != null)
        {
            // Calcular la dirección hacia el jugador
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            // Si no hay un jugador, la bala no tendrá dirección
            direction = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Player")
        {
        collision.gameObject.GetComponent<player>().life--;
        }
        // Destruir la bala al colisionar con cualquier objeto
        Destroy(gameObject);
    }
}

