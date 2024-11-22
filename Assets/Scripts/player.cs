using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public int life=5;
    public TextMeshProUGUI lifetext;

    public TextMeshProUGUI mapastext;
    int mapas;

    public GameObject menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetext.text = life.ToString();  
        mapastext.text = mapas.ToString();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Aleta"))
        {
            life--;
            Destroy(collision.gameObject);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mapa"))
        {
            mapas++;
            Destroy(other.gameObject);
        }
    }
}
