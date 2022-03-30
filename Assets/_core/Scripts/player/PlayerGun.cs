using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject LootPos;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive){return;}
        if(Input.GetKeyDown(KeyCode.E)){
            gameObject.SetActive(false);
            GameManager.Instancia.Player.pistola.gameObject.SetActive(true); 
            GameManager.Instancia.Player.tienePistola = true;   
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag != constantes.TAG_PLAYER){return;}
        isActive = true;
        GameManager.Instancia.LootUI.transform.position = LootPos.transform.position;
        GameManager.Instancia.LootUI.gameObject.SetActive(true);


    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.tag != constantes.TAG_PLAYER){return;}
        isActive = false;
        GameManager.Instancia.LootUI.gameObject.SetActive(false);

    }
}
