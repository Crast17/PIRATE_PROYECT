using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed = 10;
    public float _rotationSpeed = 180;

    public float limitX = 10f; // Límite en el eje X
    public float limitZ = 10f; // Límite en el eje Z

    private Vector3 rotation;

    public bool canMove;


    public void Update()
    {
        rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);

        if (canMove)
        {
            move = transform.TransformDirection(move);
            _controller.Move(move * _speed);
            transform.Rotate(rotation);
  
        }      

        //LIMITAR LA ZONA DE MOVIMIENTO
        Vector3 clampedPosition = this.transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -limitX, limitX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -limitZ, limitZ);

        // Actualizar posición del transform con los límites
        this.transform.position = clampedPosition;
    }
}

