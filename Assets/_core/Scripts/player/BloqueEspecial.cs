using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum BloqueType
{
    Monedas = 0,
    Hongos,
    FlorFuego
}






public class BloqueEspecial : MonoBehaviour
{   
    public SpriteRenderer sp;
    public Sprite spApagado;
    public BloqueType tipo;
    public Animator anim;
    public GameObject moneda;

    public bool active = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!active){return;}
        if(other.gameObject.tag != constantes.TAG_PLAYER){return;}
        if(GameManager.Instancia.Player.PlayerMovement.estaEnSuelo){return;}
        
            active = false;
            sp.sprite = spApagado;
            anim.Play("BloqueSalto");

        if(tipo == BloqueType.Monedas){
            AnimarMoneda();

        }else if(tipo == BloqueType.Hongos){

        }else if( tipo == BloqueType.FlorFuego){

        }

    }
    public float monedaSaltoTime;

    public void AnimarMoneda(){
        GameManager.Instancia.AgregarMoneda();
        moneda.gameObject.SetActive(true);
        moneda.transform.DOLocalMove(new Vector2(0 ,2f), monedaSaltoTime).OnComplete(MonedaOnComplete);
    }
    public void MonedaOnComplete(){
        moneda.transform.DOLocalMove(new Vector2(0, 0.5f), monedaSaltoTime)
        .SetDelay(0.1f).
        OnComplete( () => moneda.SetActive(false));
    }
}
