using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    [Header("Condiciones para 3 estrellas")]
    [Range(1,3)]
    public int vidasPara3Estrellas;

    [Range(0, 5000)]
    public int puntosPara3Estrellas;
    
    [Header("Condiciones para 2 estrellas")]
    [Range(1,3)]
    public int vidasPara2Estrellas;

    [Range(0, 5000)]
    public int puntosPara2Estrellas;

    void Start()
    {
        GameManager.Instancia.nivelActual = this;
    }

    // Update is called once per frame
    public int CalcularEstrellas(){

        if(GameManager.Instancia.puntos >= puntosPara3Estrellas 
        && GameManager.Instancia.Player.Vidas >=vidasPara3Estrellas){
            return 3;
        }
        else if(GameManager.Instancia.puntos >= puntosPara2Estrellas 
        && GameManager.Instancia.Player.Vidas >=vidasPara2Estrellas){
            return 2;
        }
        else{
            return 1;
        }
    }
}
