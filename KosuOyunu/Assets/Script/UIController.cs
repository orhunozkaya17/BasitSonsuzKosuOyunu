using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject baslangicekran;
    [SerializeField] private GameObject gameOverEkrani;
    private int skor = 0;
    private void Start()
    {
        baslangicekran.SetActive(true);
        gameOverEkrani.SetActive(false);
    }
    private void OnEnable()
    {
        Eventler.engeligecti += Eventler_engeligecti;
        Eventler.oyunbasla += Eventler_oyunbasla;
        Eventler.gameover += Eventler_oyunbitti;
    }

    private void Eventler_oyunbitti()
    {
        gameOverEkrani.SetActive(true);
    }

    private void Eventler_oyunbasla()
    {
        baslangicekran.SetActive(false);
    }

    private void OnDisable()
    {
        Eventler.engeligecti -= Eventler_engeligecti;
        Eventler.oyunbasla -= Eventler_oyunbasla;
        Eventler.gameover -= Eventler_oyunbitti;
    }
    private void Eventler_engeligecti()
    {
        skor++;
        _scoreText.text = skor.ToString();
    }
}
