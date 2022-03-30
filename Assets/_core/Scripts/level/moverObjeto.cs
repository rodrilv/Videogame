using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moverObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public float tiempo;
    public GameObject PosicionInicial;
    public GameObject PosicionFinal;
    public GameObject objetoAmover;
    void Start()
    {
        objetoAmover.transform.position = PosicionInicial.transform.position;
        objetoAmover.transform.DOMove(PosicionFinal.transform.position, tiempo).SetLoops(-1, LoopType.Yoyo);
    }
}
