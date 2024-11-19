using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderShooter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ballPrefab;
    public float shootInterval = 3f;
    private Transform player;
    public Transform shootpoint;


    void Start()
    {
        player = GameObject.Find("Player").transform;
        InvokeRepeating("ShootBall", shootInterval, shootInterval);

;    }

    // Update is called once per frame
    void ShootBall()
    {
       GameObject ball = Instantiate(ballPrefab, shootpoint.position * 2, Quaternion.identity);
        ball.GetComponent<bala>().player = player.gameObject;

    }

    void Update()
    {
        
    }
}
