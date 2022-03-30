using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionNivelMenu : MonoBehaviour
{
    private bool flag = true;

    public void ManageMenu(){
        if(flag == true){
            AbrirMenu();
            flag = false;
        }else{
            CerrarMenu();
            flag = true;
        }
    }
    // Start is called before the first frame update
    public void AbrirMenu(){
        GameManager.Instancia.AbrirMenuNivel(true);
    }
    public void CerrarMenu(){
        GameManager.Instancia.AbrirMenuNivel(false);
    }
}
