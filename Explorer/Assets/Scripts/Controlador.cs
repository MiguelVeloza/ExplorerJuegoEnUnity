using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladoJugador : MonoBehaviour
{
    Rigidbody2D rb2D;
    private float horizontal = 0f;
    public float velocidadPj;
    public float suavizado;
    private Vector3 velocidad = Vector3.zero;
    private bool volteo = true;
    public float fuerzaSalto;
    public LayerMask esSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    private bool enSuelo;
    private bool salto = false;
    private Animator animator;
    private float xInicial, yInicial;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * velocidadPj;
        if (horizontal > 0)
        {
            animator.SetBool("Run", true);
            if (salto)
            {
                animator.SetBool("Run", false);
                animator.SetBool("Jump", true);
            }
        }
        else if (horizontal < 0)
        {
            animator.SetBool("Run", true);
            if (salto)
            {
                animator.SetBool("Run", false);
                animator.SetBool("Jump", true);
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }


        if (Input.GetButtonDown("Jump"))
        {
            salto = true;

        }
        if (salto == true)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (salto == false)
        {
            animator.SetBool("Jump", false);
        }

    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, esSuelo);
        Mover(horizontal * Time.fixedDeltaTime, salto);
        salto = false;

    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObj = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObj, ref velocidad, suavizado);
        if (mover > 0 && !volteo)
        {
            Girar();
        }
        else if (mover < 0 && volteo)
        {
            Girar();
        }
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }
    private void Girar()
    {
        volteo = !volteo;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
