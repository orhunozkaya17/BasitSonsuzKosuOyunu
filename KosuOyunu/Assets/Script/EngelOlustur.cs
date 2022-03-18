using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlustur : MonoBehaviour
{
    public static EngelOlustur instance;
    const float min = 0.3f;
    const float max = 2f;
    public Material engel_materail;
    public Engel engelPrefab;


    Queue<Engel> Engelist = new Queue<Engel>();


    float toplamMasefe = 10f;
    int sayac = 0;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        Eventler.engeligecti += engeligecti_yeniengel;

    }
    private void OnDisable()
    {
        Eventler.engeligecti -= engeligecti_yeniengel;
    }
    private void engeligecti_yeniengel()
    {
        Engel engel = Engelist.Dequeue();
        toplamMasefe += 10f;
        engel.Engel_Olustur(toplamMasefe);
        Engelist.Enqueue(engel);
        Eventler.OnyeniHedefYolla(new YeniEngelArgs() { hedef = Engelist.Peek(), boxsize = new Vector2(Engelist.Peek().x, Engelist.Peek().y) });
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            toplamMasefe += i * 10;
            Engel engelPrefabb = Instantiate(engelPrefab);
            engelPrefabb.Duvar_Olustur(engel_materail);
            engelPrefabb.Engel_Olustur(toplamMasefe);
            Engelist.Enqueue(engelPrefabb);

        }

        Eventler.OnyeniHedefYolla(new YeniEngelArgs() { hedef = Engelist.Peek(), boxsize = new Vector2(Engelist.Peek().x, Engelist.Peek().y) });
    }


    public Engel Suanki_engel()
    {
        return Engelist.Peek();
    }

}
