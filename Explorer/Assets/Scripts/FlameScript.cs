using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody2D;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void FixedUpdate() {
        rigidbody2D.velocity = direction * speed;
    }

    public void SetDirection(Vector2 directionParam){
        direction = directionParam;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        BandidoScript bandido = collision.collider.GetComponent<BandidoScript>();

        if(bandido != null){
            bandido.Hit();
        }
        Destroy(gameObject);
    }
}

