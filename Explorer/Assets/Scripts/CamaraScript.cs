using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public float camaraY;
    public GameObject Personaje;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Personaje != null)
        {
            Vector3 position = transform.position;
            position.x = Personaje.transform.position.x;
            position.y = Personaje.transform.position.y + camaraY;
            transform.position = position;
        }
    }
}
