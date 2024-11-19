using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public int life=5;
    public Text lifetext;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetext.text = life.ToString();  
    }
}
