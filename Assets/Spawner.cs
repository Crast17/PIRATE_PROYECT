using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wallPrefab; // Prefab del muro
    public GameObject turretPrefab; // Prefab de la torreta
    public float spawnInterval = 2f; // Cada cuánto tiempo se generan objetos


    void Start()
    {
        InvokeRepeating("SpawnObjects", 0f, spawnInterval); // Llamar a SpawnObjects cada 2 segundos
    }


    void SpawnObjects()
    {
        float rand = Random.Range(0f, 100f);

        if (rand > 60f)
        {
            // Generar muro
            Instantiate(wallPrefab, transform.position, Quaternion.identity);
        }
        else if (rand <= 15f)
        {
            // Generar torreta
            Instantiate(turretPrefab, transform.position, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
