using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public GameObject spawn;

    public CinemachineVirtualCamera VirtualCamera;

    bool firstime = true;
    public GameObject gameCanvas;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //DEJAR EL PLAYER MOVERSE
        PlayerMovement.canMove = true;
        //ACTIVAR EL SPAWN
        spawn.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;

        if(firstime)
        {
            VirtualCamera.Priority = 20;
            gameCanvas.SetActive(true);
           
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
