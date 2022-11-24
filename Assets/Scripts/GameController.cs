using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState {Espera,Corriendo };
    public GameState gameState=GameState.Espera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState==GameState.Espera && Input.GetMouseButtonDown(0))
        {
            gameState=GameState.Corriendo;
        }
        else if(gameState==GameState.Corriendo)
        {
            //animaciones
        }
    }
}
