using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //private int monedas = 0;
    public playerMovement PlayerMovement;
    public SpriteRenderer spriteRenderer;
    public Sprite spWhite;
    public Sprite spSad;
    public Sprite spDead;
    public Animator anim;
    public int Vidas;
    public bool esInmune = false;
    public bool llave;
    
    [Header("Pistola")]
    public GameObject pistola;
    public int Balas;
    public GameObject bala;
    public bool tienePistola = false;


    // Start is called before the first frame update
    void Start()
    {
        Vidas = constantes.MAX_VIDAS;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            if(tienePistola == false){return;}else{Disparar(); AudioManager.Instancia.Audio_BalaCanon_Dispara();}
            
        }
    }

    public void Disparar(){
        Instantiate(bala, pistola.transform.position, pistola.transform.rotation);
    }

    public void ResetPlayer(){
        pistola.gameObject.SetActive(false);
        tienePistola = false;
        Vidas = constantes.MAX_VIDAS;
        esInmune = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == constantes.TAG_MONEDA)
        {
            EsMoneda(other);
        }
        else if (other.tag == constantes.TAG_ENEMIGO /*|| other.tag == constantes.TAG_ENEMIGO_AP*/ )
        {
            Debug.Log("Daño recibido");
            if ( /*other.tag == constantes.TAG_ENEMIGO_AP*/other.GetComponent<enemy>().sePuedePisar && PlayerMovement.rb.velocity.y < 0)
            {
                EsEnemigo(other);
            }
            else if (!esInmune)
            {
                HacerDano();
                GameManager.Instancia.QuitarMonedas();
            }
        }
        else if (other.tag == constantes.TAG_PUERTA)
        {
            EsPuerta();
        }
        else if(other.tag == constantes.TAG_BARRANCO){
            GameManager.Instancia.GameOver(true);
            Debug.Log("GAME OVER");
        }
        else if(other.tag == constantes.TAG_CORAZON){
            EsCorazon(other);
        }else if (other.tag == constantes.TAG_LLAVE) {
            EsLlave(other);
        }else if(other.tag == constantes.TAG_RESORTE){
            EsResorte(other);
        }else if(other.tag == constantes.TAG_PUERTA_LLAVE){
            EsPuertaLlave();
        }
    }
    private void HacerDano()
    {
        if(Vidas == 0 ){ PlayerMovement.bloquearMovimiento = true; PlayerMovement.rb.velocity = Vector2.zero;  }else {Vidas --;}
        esInmune = true;
        GameManager.Instancia.QuitarVida(Vidas);
        if (Vidas <= 0)
        {
            
            GameManager.Instancia.GameOver(true);
        }
        //1
        PlayerMovement.bloquearMovimiento = true;
        PlayerMovement.rb.velocity = Vector2.zero;
        //2
        anim.enabled = false;
        spriteRenderer.sprite = spWhite;
        //3
        if (PlayerMovement.facingRight)
        {
            PlayerMovement.rb.AddForce(new Vector2(30, 400));
        }
        else
        {
            PlayerMovement.rb.AddForce(new Vector2(-30, 400));
        }
        //4
        AudioManager.Instancia.Audio_RecibirDaño();
        InvokeRepeating("Parpadeo", 0, 0.1f);
        Invoke("QuitarSpriteBlanco", 0.4f);
        //5
        Invoke("RegresoAnormalidad", 1);

    }
    public void Parpadeo()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
    public void QuitarSpriteBlanco()
    {
        spriteRenderer.sprite = spSad;
    }
    public void RegresoAnormalidad()
    {
        esInmune = false;
        PlayerMovement.bloquearMovimiento = false;
        PlayerMovement.rb.velocity = Vector2.zero;
        CancelInvoke("Parpadeo");

        anim.enabled = true;
    }
    public void EsPuerta()
    {
        GameManager.Instancia.NivelCompletado(true);
        Debug.Log("Nivel Completado");
    }
    public void EsEnemigo(Collider2D other)
    {
        other.GetComponent<enemy>().HacerDaño();
        PlayerMovement.rb.velocity = Vector2.zero;
        
        PlayerMovement.rb.AddForce(new Vector2(0, 700));
    }
    public void EsMoneda(Collider2D other)
    {
        other.gameObject.SetActive(false);
        //monedas += 1;
        GameManager.Instancia.AgregarMoneda();
    }
    public void EsCorazon(Collider2D other){
        //other.gameObject.
        other.gameObject.SetActive(GameManager.Instancia.AgregarVida(Vidas));
        //GameManager.Instancia.AgregarVida(Vidas);
    }
    public void EsResorte(Collider2D other){
        PlayerMovement.rb.AddForce(new Vector2(0, 2000));
        AudioManager.Instancia.Audio_Resorte();   
        
    }
    public void EsPuertaLlave(){
        if(llave == false){
            Debug.Log("Cerrada!");
            AudioManager.Instancia.Audio_Cerrada();
        }else if(llave == true){
            EsPuerta();
            GameManager.Instancia.UsoLlave();
        }
    }

    public void EsLlave(Collider2D other){
        GameManager.Instancia.AgarrarLlave();
        other.gameObject.SetActive(false);
        
    }
}
