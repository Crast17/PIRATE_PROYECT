using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class Aleta : MonoBehaviour
{
    public float speed;

    NavMeshAgent agent;
    GameObject player;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void OnEnable()
    {
        player = GameObject.Find("PLAYER");
    
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

}
