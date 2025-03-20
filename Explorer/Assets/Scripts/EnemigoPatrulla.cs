using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour {

    public float velocidad = 2.0f;
    public Transform puntoIzquierdo;
    public Transform puntoDerecho;
    bool moviendoseDerecha = true;
    SpriteRenderer enemigoSprite;

    void Start() {
        transform.position = puntoIzquierdo.position;
        enemigoSprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (moviendoseDerecha) {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            if (transform.position.x >= puntoDerecho.position.x) {
                moviendoseDerecha = false;
                enemigoSprite.flipX = false;
            }
        } else {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            if (transform.position.x <= puntoIzquierdo.position.x) {
                moviendoseDerecha = true;
                enemigoSprite.flipX = true;
            }
        }
    }
}