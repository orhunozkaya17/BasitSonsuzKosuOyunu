using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haraket : MonoBehaviour
{
    [SerializeField] float hiz = 3f;
    gameState gameState;
    void Start()
    {
        gameState = gameState.baslangic;
    }
    private void OnEnable()
    {
        Eventler.oyunbasla += oyunbasla_OyunBasla;
        Eventler.gameover += oyunbasla_oyunBitti;
    }

    private void oyunbasla_oyunBitti()
    {
        gameState = gameState.gameOver;
    }

    private void oyunbasla_OyunBasla()
    {
        gameState = gameState.game;
    }

    private void FixedUpdate()
    {
        if (gameState == gameState.baslangic || gameState == gameState.gameOver)
        {
            return;
        }
        transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * hiz;
    }
}
