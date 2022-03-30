using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : enemy
{
    public Rigidbody2D rb2d;
    public int velocidad;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = new Vector2(velocidad, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag != constantes.TAG_ESCENARIO){return;}

        rb2d.velocity = new Vector2(rb2d.velocity.x * -1, 0);
        transform.Rotate(0, 180, 0);
    }       
}

