using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalLevel : MonoBehaviour
{
    public bool isActive;
    public GameObject LootPos, Diag0, Diag1, Diag2, Diag3;
    public int dialogo;
    void Start()
    {
        dialogo = 0;
        AudioManager.Instancia.Audio_Entorno_1(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive){return;}
        if(Input.GetKeyDown(KeyCode.E)){
            if(dialogo == 0){
                Diag0.SetActive(true);
                Debug.Log("El valor es"+dialogo);
                dialogo ++;
            }else if(dialogo == 1){
                Diag0.SetActive(false);
                Diag1.SetActive(true);
                dialogo ++;
            }else if(dialogo == 2){
                Diag1.SetActive(false);
                Diag2.SetActive(true);
                Debug.Log("El valor es"+dialogo);
                dialogo ++;
            }else if(dialogo == 3){
                Diag2.SetActive(false);
                Diag3.SetActive(true);
                Debug.Log("El valor es"+dialogo);
                dialogo ++;
            }else if(dialogo == 4){
                Diag3.SetActive(false);
                Debug.Log("El valor es"+dialogo);
                GameManager.Instancia.NivelCompletado(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        GameManager.Instancia.Player.PlayerMovement.BloquearMovimiento();
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
