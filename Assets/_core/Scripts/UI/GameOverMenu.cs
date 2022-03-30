using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnRetryClick(){
        GameManager.Instancia.GameOver(false);
        //SceneManager.LoadScene("game");   
        GameManager.Instancia.Retry();
    }
}
