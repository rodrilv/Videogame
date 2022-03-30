using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int monedas = 0;
    public player Player;
    public Nivel nivelActual;
    public List<vida> vidasList;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI puntosText;
    

    public PuntosEfecto puntosText_Efecto;
    public static GameManager Instancia;
    public int puntos;

    public GameObject gameOverMenu;
    public GameObject llave;
    public GameObject nivelCompletadoMenu;
    public GameObject seleccionDeNivelMenu;
    public GameObject LootUI; 
    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Retry()
    {
        OnGameReset();
        LevelManager.Instancia.Retry();
    }
    public void NivelCompletado(bool status)
    {

        Player.PlayerMovement.BloquearMovimiento();
        nivelCompletadoMenu.gameObject.SetActive(status);

    }
    public void GameOver(bool status)
    {
        Player.PlayerMovement.BloquearMovimiento();
        gameOverMenu.gameObject.SetActive(status);
        if(status == true){
            AudioManager.Instancia.Audio_GameOver();
        }
        
    }
    public void AgregarPuntos(int _puntos, Vector2 _posicion)
    {
        puntos += _puntos;


        puntosText_Efecto.gameObject.SetActive(true);
        puntosText_Efecto.ShowText(_puntos.ToString(), _posicion);
    }
    public void ActualizarPuntos()
    {
        puntosText.text = puntos.ToString();
    }
    public void AgregarMoneda()
    {   
        
        monedas += 1;
        monedasText.text = ("x " + monedas.ToString());
        Debug.Log("Monedas: " + monedas);
        AudioManager.Instancia.Audio_Moneda();

    }
    public void QuitarMonedas()
    {
        monedas -= 1;
        monedasText.text = ("x " + monedas.ToString());
    }

    public void AgregarVida(int _vida)
    {
        if (Player.Vidas >= constantes.MAX_VIDAS)
        {
            Player.Vidas = constantes.MAX_VIDAS;
        }
        else if(Player.Vidas < constantes.MAX_VIDAS)
        {
            Player.Vidas = Player.Vidas + 1;
            vidasList[_vida].PrenderVida();
            AudioManager.Instancia.Audio_Vida();
        }
    }

    public void QuitarVida(int _vidas)
    {

        vidasList[_vidas].ApagarVida();
    }
    public void OnGameReset()
    {

        Player.ResetPlayer();
        foreach (var vida in vidasList)
        {
            vida.PrenderVida();
        }

        monedas = 0;
        monedasText.text = monedas.ToString();

        puntos = 0;
        puntosText.text = puntos.ToString();
    }

    public void AbrirMenuNivel(bool status){
        seleccionDeNivelMenu.gameObject.SetActive(status);
    }
    public void AgarrarLlave(){
        Player.llave = true;
        llave.gameObject.SetActive(true);
        AudioManager.Instancia.Audio_TomarLlave();
    }

    public void UsoLlave(){
        Player.llave = false;
        llave.gameObject.SetActive(false);
    }

    
}
