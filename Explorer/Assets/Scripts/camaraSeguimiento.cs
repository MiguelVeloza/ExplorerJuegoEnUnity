using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSeguimiento : MonoBehaviour {

    public Transform personaje;
    public float velocidadSeguimiento;
    public float offsetX;
    public float offsetY;

    void Update() {
        Vector3 posicionObjetivo = new Vector3(personaje.position.x + offsetX, personaje.position.y + offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, velocidadSeguimiento * Time.deltaTime);
    }
}