using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public GameObject spawn;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {

        PlayerMovement.canMove = true;
        spawn.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
