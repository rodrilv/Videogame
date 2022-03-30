using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class UI_NivelBoton : MonoBehaviour
{
    public Button nivelBoton;
    public int nivel;
    public TextMeshProUGUI nombreNivel;
    public List<Image> estrellas;
    // Start is called before the first frame update
    void Start()
    {
        nivelBoton.onClick.AddListener(OnLevelSelect);
        PonerNombre();
        SetupEstrellas();
    }

    // Update is called once per frame
    public void OnLevelSelect(){
        Debug.Log("Boton presionado " + nivel);
        GameManager.Instancia.AbrirMenuNivel(false);
        GameManager.Instancia.OnGameReset();
        LevelManager.Instancia.CargarNivel(nivel);

        
        
        
    }
    public void PonerNombre(){
        nombreNivel.text = "Nivel "+nivel;
    }
    public void SetupEstrellas(){
        int cuantasEstrellas = DataManager.Instancia.CargarEstrellas("Nivel_" + nivel);

        for(int i = 0; i < cuantasEstrellas; i++){
            estrellas[i].color = Color.white;
        }
    }
}
