using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded = true; // Puedes cambiar esto según tu lógica de detección de suelo

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detectar movimiento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = Mathf.Abs(moveInput) > 0.1f;

        // Actualizar el parámetro "Speed" en el Animator
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Mover al jugador horizontalmente
        rb.velocity = new Vector2(moveInput * 5f, rb.velocity.y);

        // Detectar el salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Resetear la velocidad vertical
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Detectar si el jugador deja de estar en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
