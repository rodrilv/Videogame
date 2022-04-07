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
        clima();
    }
    

    // Update is called once per frame
    public void Retry(){
        GameManager.Instancia.Player.transform.parent = GameManager.Instancia.playerParent.transform;   
        loadingMenu.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        clima();
    }
    public void SiguienteNivel()
    {   
        GameManager.Instancia.OnGameReset();
        GameManager.Instancia.Player.transform.parent = GameManager.Instancia.playerParent.transform;
        if(nivelActual < 5){   
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual += 1;
        clima();}
        else{ 
            GameManager.Instancia.LootUI.gameObject.SetActive(false);
            SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
            nivelActual = 1;

  }

    }

    private void TerminoDeQuitarEscena(Scene scene)
    {
        GameManager.Instancia.Player.transform.parent = GameManager.Instancia.playerParent.transform;   
        Debug.Log("Escena Descargada!");
        SceneManager.LoadScene("Nivel_" + nivelActual, LoadSceneMode.Additive);
    }

    private void EscenaTerminoDeCargar(Scene scene, LoadSceneMode mode)
    {
        loadingMenu.gameObject.SetActive(false);
    }

    public void CargarNivel(int nivel){
        GameManager.Instancia.Player.transform.parent = GameManager.Instancia.playerParent.transform;   
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual = nivel;
        clima();
    }

    public void clima(){
        if(nivelActual == 1){
            GameManager.Instancia.camera.backgroundColor = new Color(0.2021627f, 0.4805751f, 0.7264151f);
        }else if (nivelActual == 2){
            GameManager.Instancia.camera.backgroundColor = new Color(0.4811321f, 0.3864571f, 0.2246796f);
        }else if(nivelActual == 3){
            GameManager.Instancia.camera.backgroundColor = new Color(0.1f, 0.1f, 0.1f);
        }else if(nivelActual == 4){
            GameManager.Instancia.camera.backgroundColor = new Color(0.1f, 0.1f, 0.1f);
        }else if(nivelActual == 5){
            GameManager.Instancia.camera.backgroundColor = new Color(0.0f, 0.0f, 0.0f);
        }
    }
}
