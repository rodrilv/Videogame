using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public ParticleSystem particulas;
    public SpriteRenderer sp;
    public BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != constantes.TAG_PLAYER){ return; }
        //if (GameManager.Instancia.Player.PlayerMovement.rb.velocity.y < 0){ return; }
        if(GameManager.Instancia.Player.PlayerMovement.estaEnSuelo){ return; }
        particulas.Play();
        sp.enabled = false;
        collider.enabled = false;
        AudioManager.Instancia.Audio_RomperBloque();



    }
}
