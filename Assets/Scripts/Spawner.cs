using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public GameObject aleta; 
    public GameObject mapa; 
    public GameObject coin; 

    public float cooldownMapa;
    public float cooldownAleta;
    public float cooldownCoin;

    public Vector3 minPosition; // Límite inferior del rango (X, Y, Z)
    public Vector3 maxPosition; // Límite superior del rango (X, Y, Z)

    public GameObject[] spawnsAleta;

    public int tiempoDestroyMapa;
    public int tiempoDestroyCoin;
    public int tiempoDestroyAleta;
        
    void Start()
    {
        InvokeRepeating("SpawnMapa", 15f, cooldownMapa); 
        InvokeRepeating("SpawnCoin", 5f, cooldownCoin); 

        StartCoroutine(SpawnAleta());
    }

    IEnumerator SpawnAleta()
    {
        Debug.Log("Spawn aleta");
        yield return new WaitForSeconds(cooldownAleta);

        int randomSpawn = Random.Range(0,spawnsAleta.Length);

        GameObject newAleta = Instantiate(aleta, spawnsAleta[randomSpawn].transform.position,Quaternion.identity);
        Destroy(newAleta,tiempoDestroyAleta);
        if(cooldownAleta > 1f)
        {
            cooldownAleta = cooldownAleta - 0.25f;
        }
       
        StartCoroutine(SpawnAleta());
    }
    public void StartPowerUp()
    {
        StartCoroutine(PowerUp());
    }
    void SpawnMapa()
    {        
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);

        GameObject newMap = Instantiate(mapa, spawnPosition, Quaternion.identity);
        Destroy(newMap,tiempoDestroyCoin);

    }
    
    void SpawnCoin()
    {
        Debug.Log("Spawn coin " + cooldownCoin);
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);

        GameObject newCoin =  Instantiate(coin, spawnPosition, Quaternion.identity);
        Destroy(newCoin,tiempoDestroyCoin);

    }
    IEnumerator PowerUp()
    {
        cooldownCoin /= 2;
        yield return new WaitForSeconds(15f);

        cooldownCoin *= 2;
    }
    private void OnDrawGizmos()
    {
        // Establecer color para el Gizmo
        Gizmos.color = Color.green;

        // Calcular el tamaño del área del Gizmo
        Vector3 center = (minPosition + maxPosition) / 2; // Centro del rango
        Vector3 size = maxPosition - minPosition;         // Tamaño del rango

        // Dibujar un cubo representando el área de spawn
        Gizmos.DrawWireCube(center, new Vector3(size.x, 0, size.z));
    }
}
