using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    public float velocidad;
    public float salto;
    public bool estaEnSuelo;
    public Animator anim;
    public bool bloquearMovimiento;

    void Start()
    {
        //Debug.Log("Hola");
        //rb.gravityScale = -1;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Tecla A presionada" + Input.GetKeyDown(KeyCode.A));
        //Debug.Log("Tecla A presionada" + Input.GetAxisRaw("Horizontal"));
        if (bloquearMovimiento) { return; }
        ChecarSuelo();
        CheckMovimiento();
        CheckJump();
        Voltear();

        anim.SetBool("IsJumping", !estaEnSuelo);
    }
    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            Debug.Log("Salta");
            rb.velocity = new Vector2(horizontal * velocidad, salto);
            AudioManager.Instancia.Audio_Salto();

        }
    }
    private void CheckMovimiento()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * velocidad, rb.velocity.y);
        anim.SetBool("IsMoving", horizontal != 0);
    }
    private void ChecarSuelo()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector2.down, 1f))
        {
            estaEnSuelo = true;
        }
        else
        {
            estaEnSuelo = false;
        }
    }
    public bool facingRight = true;
    private void Voltear()
    {
        if ((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);

        }
    }

    public void BloquearMovimiento(){
        bloquearMovimiento = true;
        rb.velocity = Vector2.zero;
    }

    public void DesbloquearMovimiento(){
        bloquearMovimiento = false;
    }
}