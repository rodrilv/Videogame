using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instancia.Player.transform.position = this.transform.position;
        GameManager.Instancia.Player.PlayerMovement.DesbloquearMovimiento();
    }
    
}
