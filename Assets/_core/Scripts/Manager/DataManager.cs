using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instancia;
    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
    }

    // Update is called once per frame
    public void GuardarEstrellas(string _nivel, int _cuantasEstrellas){
        PlayerPrefs.SetInt(_nivel, _cuantasEstrellas);
        
    }
    public int CargarEstrellas(string _nivel){
        int cuantasEstrellas = PlayerPrefs.GetInt(_nivel);
        return cuantasEstrellas;
    }
}