using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    public AudioSource soundJump;

    public float runSpeed=2;    // Movimiento en el eje horizontal
    public float jumpSpeed = 3; // 

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier =1f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey("d") || (Input.GetKey("right")))       
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true); 
        }
        else if (Input.GetKey("a") || (Input.GetKey("left")))   
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true); 
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            animator.SetBool("Run", false); 
        }
        if (Input.GetKey("w") && CheckGround.isGrounded) 
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            soundJump.Play();
        }

        if (CheckGround.isGrounded==false)  // Comprobar si estamos en el aire saltando
        {
            animator.SetBool("Jump", true); // Activar parametro salto
            animator.SetBool("Run", false); // Desactivar  parametro correr
        }
        if (CheckGround.isGrounded==true)   // Comprobar si estamos en el suelo
        {
            animator.SetBool("Jump", false);// Desactivar parametro salto
        }


        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            if (rb2D.linearVelocity.y > 0 && !Input.GetKey("w"))
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }


    }
}
