using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        if(GameManager.Instancia.Player == null){return;}
        GameManager.Instancia.Player.transform.parent = GameManager.Instancia.playerParent.transform;   
        GameManager.Instancia.Player.transform.position = this.transform.position;
        GameManager.Instancia.Player.PlayerMovement.DesbloquearMovimiento();
    }
    
}
