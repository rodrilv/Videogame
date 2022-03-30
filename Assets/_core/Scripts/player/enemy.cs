using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spWhite;
    public Animator anim;
    public BoxCollider2D bx;
    public AudioSource Sonido;
    public bool sePuedePisar = true;
    int puntos = 100;
    public void HacerDaño(){

        

        anim.enabled = false;
        bx.enabled = false;
        spriteRenderer.sprite = spWhite;

        Invoke("ApagarEnemigo", 0.4f);
        GameManager.Instancia.AgregarPuntos(puntos, transform.position);
        Reproducir();
        
    }
    private void ApagarEnemigo(){
        gameObject.SetActive(false);
    }
    public void enemyDamage(){

        
        spriteRenderer.enabled = false;

    }
    public void Parpadeo()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
    public void Reproducir(){
        Sonido.Play();
    }
   
}
