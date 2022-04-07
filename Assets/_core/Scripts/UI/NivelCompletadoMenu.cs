using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NivelCompletadoMenu : MonoBehaviour
{
    public Button okButton;
    public List<UI_Estrella> estrellas;
    // Start is called before the first frame update
    void OnEnable(){
        ResetMenu();
        int estrellas = GameManager.Instancia.nivelActual.CalcularEstrellas();
        PrenderEstrellas(estrellas);
        DataManager.Instancia.GuardarEstrellas("Nivel_"+LevelManager.Instancia.nivelActual, estrellas);

    }
    public void PrenderEstrellas(int _cuantas){
        estrellasPorPrender = _cuantas;
        InvokeRepeating("PrenderEstrellaDelay", 0, 1);
    }
    int iterador = 0;
    int estrellasPorPrender = 0;
    public void PrenderEstrellaDelay(){
        estrellas[iterador].PrenderEstrella();
        iterador++;

        if(iterador >= estrellasPorPrender){
            CancelInvoke("PrenderEstrellaDelay");
            okButton.interactable = true;
        }
    }
    public void OnOkClick(){
        GameManager.Instancia.NivelCompletado(false);
        LevelManager.Instancia.SiguienteNivel(); 
        AudioManager.Instancia.Audio_Entorno_1(false);  
    }

    public void ResetMenu(){
        iterador = 0;
        estrellasPorPrender = 0;

        foreach (var estrella in estrellas){
            estrella.ApagarEstrella();
        }
    }
}
