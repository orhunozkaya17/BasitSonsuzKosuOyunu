using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerr : MonoBehaviour
{
    private void OnEnable()
    {
        Eventler.gameover += Eventler_gameover;
    }
   
    gameState gameState = gameState.game;
    private void Eventler_gameover()
    {
        gameState = gameState.gameOver;

    }

    private void Update()
    {
        if (gameState != gameState.gameOver)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
