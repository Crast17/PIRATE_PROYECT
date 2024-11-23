using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public int life=5;
    public TextMeshProUGUI lifetext;
    public TextMeshProUGUI mapastext;

    int monedas;

    public GameObject menu;
    public Spawner spawner;

   
    // Update is called once per frame
    void Update()
    {
        //ACTUALIZAR LA VIDA Y LAS MONEDAS A LA INTERFAZ
        lifetext.text = life.ToString();  
        mapastext.text = monedas.ToString();

        //ACTIVAR EL MENU AL DARLE AL ESCAPE
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;            
        }
        //SI MUERES REINICIAR LA ESCENA
        if (life <= 0) SceneManager.LoadScene(0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SI TOCO LA ALETA RESTO VIDA
        if (collision.gameObject.CompareTag("Aleta"))
        {         
            life--;
            Destroy(collision.gameObject);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        //SI TOCO MONEDA SUMO EL CONTADOR
        if (other.gameObject.CompareTag("Coin"))
        {
            monedas++;
            Destroy(other.gameObject);
        }
        //SI TOCO EL MAPA SE ACTIVA EL POWER UP(REDUCE EL TIEMPO DE COOLDOWN DE LAS MONEDAS A LA MITAD
        if (other.gameObject.CompareTag("Mapa"))
        {
            spawner.StartPowerUp();
            Destroy(other.gameObject);
        }
    }
}
