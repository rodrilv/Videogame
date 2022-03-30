using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PuntosEfecto : MonoBehaviour
{
    public TextMeshPro texto;
    public float tiempoDeSalto;
    // Start is called before the first frame update
    public void ShowText(string _text, Vector2 _posicion)
    {
        texto.text = _text;
        transform.position = _posicion;

        Invoke("saltarAcontador", 1);

    }

    public void saltarAcontador()
    {
        transform.DOJump(GameManager.Instancia.puntosText.transform.position, -3, 1, tiempoDeSalto)
        .OnComplete(MovimientoCompletado);

    }
    private void MovimientoCompletado()
    {
        gameObject.SetActive(false);
        GameManager.Instancia.ActualizarPuntos();
    }
}
