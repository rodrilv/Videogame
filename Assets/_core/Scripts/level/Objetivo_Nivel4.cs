using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo_Nivel4 : MonoBehaviour
{
    public GameObject celda;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instancia.puntos == 3100){
            AudioManager.Instancia.Audio_Palanca_Activada();
            celda.gameObject.SetActive(false);
        }else{

        }
    }
}
