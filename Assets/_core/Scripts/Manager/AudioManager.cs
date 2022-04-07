using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instancia;
    public List<AudioSource> Sonidos;
    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
    }

    // Update is called once per frame
    public void Audio_Salto(){
        Sonidos[0].Play();
    }
    public void Audio_Moneda(){
        Sonidos[1].Play();
    }
    public void Audio_Cerrada(){
        Sonidos[2].Play();
    }
    public void Audio_TomarLlave(){
        Sonidos[3].Play();
    }
    public void Audio_RomperBloque(){
        Sonidos[4].Play();
    }
    public void Audio_RecibirDaño(){
        Sonidos[5].Play();
    }
    public void Audio_Resorte(){
        Sonidos[6].Play();
    }
    public void Audio_Araña_Down(){
        Sonidos[7].Play();
    }
    public void Audio_Frog_Down(){
        Sonidos[8].Play();
    }
    public void Audio_Palanca_Activada(){
        Sonidos[9].Play();
    }
    public void Audio_Vida(){
        Sonidos[10].Play();
    }
    public void Audio_BalaCanon_Explota(){
        Sonidos[11].Play();
    }
    public void Audio_GameOver(){
        Sonidos[12].Play();
    }
    public void Audio_BalaCanon_Dispara(){
        Sonidos[13].Play();
    }
    public void Audio_Entorno_1(bool status){
        if(status == true){
            Sonidos[14].Play();
        }else{
            Sonidos[14].Stop();
        }
        
    }
}
