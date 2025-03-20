using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject flamePrefab;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float horizontal;
    public bool isGrounded;
    
    private int health = 5;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Atacar();
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f)
        {

        };
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        animator.SetBool("running", horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            isGrounded = true;
        }
        else isGrounded = false;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        animator.SetTrigger("salto");
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void AtacarEspada()
    {
        animator.SetTrigger("ataqueEspada");
    }

    private void AtacarLanza()
    {
        animator.SetTrigger("ataqueLanza");
    }

    private void AtacarMartillo()
    {
        animator.SetTrigger("ataqueMartillo");
    }

    private void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AtacarEspada();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            AtacarLanza();
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            AtacarMartillo();
        }
    }

    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject flame = Instantiate(flamePrefab, transform.position + direction * 0.3f, Quaternion.identity);
        flame.GetComponent<Flame>().SetDirection(direction);

        Destroy(flame, 2.0f);

    }

    public void Hit(){
        health = health - 1;
        if(health == 0) Destroy(gameObject);
    }
}
