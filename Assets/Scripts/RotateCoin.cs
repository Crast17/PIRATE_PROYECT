using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //ROTAR
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
