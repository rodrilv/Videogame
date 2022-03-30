using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Estrella : MonoBehaviour
{
    public Image imagen;
    // Start is called before the first frame update
    public void PrenderEstrella(){
        imagen.color = Color.white;

        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        transform.DOScale(1, 0.5f);
    }
    public void ApagarEstrella(){
        imagen.color = Color.black;
    }
}
