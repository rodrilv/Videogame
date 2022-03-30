using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager Instancia;
    public int nivelActual;
    public GameObject loadingMenu;
    void Start()
    {
        Instancia = this;

        SceneManager.sceneUnloaded += TerminoDeQuitarEscena;
        SceneManager.sceneLoaded += EscenaTerminoDeCargar;
    }
    

    // Update is called once per frame
    public void Retry(){
        loadingMenu.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        
    }
    public void SiguienteNivel()
    {
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual += 1;
    }

    private void TerminoDeQuitarEscena(Scene scene)
    {
        Debug.Log("Escena Descargada!");
        SceneManager.LoadScene("Nivel_" + nivelActual, LoadSceneMode.Additive);
    }

    private void EscenaTerminoDeCargar(Scene scene, LoadSceneMode mode)
    {
        loadingMenu.gameObject.SetActive(false);
    }

    public void CargarNivel(int nivel){
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual = nivel;
    }
}
