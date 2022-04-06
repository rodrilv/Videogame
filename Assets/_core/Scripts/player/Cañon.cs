using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public SpriteRenderer sp;
    public CapsuleCollider2D cc2d;
    public GameObject Bala; 
    public Rigidbody2D rb;
    public float speed;
    public float X;
    public float Y;
    public ParticleSystem particle;
    void Start()
    {
        //rb.velocity = transform.right * speed;
        
        if(GameManager.Instancia.Player.PlayerMovement.facingRight == true){
            rb.AddForce(new Vector2(X, Y));
        }else{
            rb.AddForce(new Vector2(-(X), Y));
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag == constantes.TAG_PLAYER || other.tag == constantes.TAG_BALA || other.tag == constantes.TAG_CORAZON || other.tag == constantes.TAG_MONEDA){return;}
        
        //Bala.gameObject.SetActive(false);
        particle.Play();
        sp.enabled = false;
        cc2d.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        
        
        //rb.enabled = false;

        AudioManager.Instancia.Audio_BalaCanon_Explota();
        
        if(other.tag == constantes.TAG_ENEMIGO){
            GameManager.Instancia.Player.EsEnemigo(other);
        }
    }
}
