using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandidoScript : MonoBehaviour
{
    private int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(){
        health = health - 1;
        if(health == 0) Destroy(gameObject);
    }
}
