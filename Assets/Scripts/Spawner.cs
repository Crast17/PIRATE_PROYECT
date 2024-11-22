using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   

    public GameObject aleta; 
    public GameObject mapa; 

    public float cooldownMapa;
    public float cooldownAleta;

    public Vector3 minPosition; // L�mite inferior del rango (X, Y, Z)
    public Vector3 maxPosition; // L�mite superior del rango (X, Y, Z)

    public GameObject[] spawnsAleta;
        
    void Start()
    {
        InvokeRepeating("SpawnMapa", 5f, cooldownMapa); 

        StartCoroutine(SpawnAleta());
    }

    IEnumerator SpawnAleta()
    {
        Debug.Log("Spawn aleta");
        yield return new WaitForSeconds(cooldownAleta);

        int randomSpawn = Random.Range(0,spawnsAleta.Length);

        Instantiate(aleta, spawnsAleta[randomSpawn].transform.position,Quaternion.identity);

        if(cooldownAleta > 1f)
        {
            cooldownAleta = cooldownAleta - 0.25f;
        }
       
        StartCoroutine(SpawnAleta());
    }

    void SpawnMapa()
    {
        Debug.Log("Spawn Mapa");
        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);

        Instantiate(mapa, spawnPosition, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        // Establecer color para el Gizmo
        Gizmos.color = Color.green;

        // Calcular el tama�o del �rea del Gizmo
        Vector3 center = (minPosition + maxPosition) / 2; // Centro del rango
        Vector3 size = maxPosition - minPosition;         // Tama�o del rango

        // Dibujar un cubo representando el �rea de spawn
        Gizmos.DrawWireCube(center, new Vector3(size.x, 0, size.z));
    }
}
