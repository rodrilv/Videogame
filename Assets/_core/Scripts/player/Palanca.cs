using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LootPos;
    public GameObject Cell;
    public GameObject PalancaLeft;
    public GameObject PalancaRight;
    public bool isActive;

    void Update(){
        if(!isActive){return;}
        if(Input.GetKeyDown(KeyCode.E)){

            PalancaLeft.gameObject.SetActive(false);
            PalancaRight.gameObject.SetActive(true);
            Cell.gameObject.SetActive(false);
            AudioManager.Instancia.Audio_Palanca_Activada();
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
