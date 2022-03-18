using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyutlandirma : MonoBehaviour
{
    [SerializeField] Transform ghost;


    float Xmin = 0.3f;
    float Xmax = 2f;
    float Ymin = 0.3f;
    float Ymax = 2f;
    private float x, y;
    Vector3 sonKonum;
    bool basma_aktif_mi = true;
    //ghost degiskenleri
    public Color pozitifRenk;
    public Color negetifRenk;
    private Material ghostMaterial;
    Engel ghost_pos;
    Vector2 ghost_size;

    gameState game_state;
    private void Start()
    {
        game_state = gameState.baslangic;
        x = transform.localScale.x;

        y = transform.localScale.y;
        ghostMaterial = ghost.GetComponent<MeshRenderer>().material;
    }
    private void OnEnable()
    {
        Eventler.engeligecti += engeligecti_Engeligecti;
        Eventler.engeleGirdi += Eventler_engeleGirdi;
        Eventler.yeniHedefYolla += yeniHedefYolla_YeniHedef;
    }



    private void OnDisable()
    {
        Eventler.engeligecti -= engeligecti_Engeligecti;
        Eventler.engeleGirdi -= Eventler_engeleGirdi;
        Eventler.yeniHedefYolla -= yeniHedefYolla_YeniHedef;
    }





    private void Update()
    {
        if (game_state == gameState.gameOver)
        {
            return;
        }
        if (game_state == gameState.baslangic)
        {
            if (Input.GetMouseButton(0))
            {
                game_state = gameState.game;
                Eventler.ONOyunBasla();
            }
            return;
        }
        Ayarla();
        GhostAyarla();
    }
    void Ayarla()
    {
#if UNITY_STANDALONE_WIN
        PC();
#else
        Telefon();
#endif
    }
    private void Telefon()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            if (basma_aktif_mi)
            {
                sonKonum = Input.GetTouch(0).position;
                basma_aktif_mi = false;
                return;
            }
            float fark = Input.GetTouch(0).position.y - sonKonum.y;
            if (fark > 0)
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }
            else
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }

            sonKonum = Input.GetTouch(0).position;
            if (x > Xmax || y > Ymax)
            {

                return;
            }
            x = Mathf.Clamp(x, Xmin, Xmax);
            y = Mathf.Clamp(y, Xmin, Xmax);
            transform.localScale = new Vector3(x, y, 1);
            transform.position = new Vector3(0, y / 2, transform.position.z);
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                basma_aktif_mi = true;
            }
        }

    }
    private void PC()
    {
        if (Input.GetMouseButton(0))
        {
            if (basma_aktif_mi)
            {
                sonKonum = Input.mousePosition;
                basma_aktif_mi = false;
                return;
            }
            float fark = Input.mousePosition.y - sonKonum.y;
            if (fark > 0)
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }
            else
            {
                x -= Time.deltaTime * fark;
                y += Time.deltaTime * fark;
            }

            sonKonum = Input.mousePosition;
            if (x > Xmax || y > Ymax)
            {

                return;
            }
            x = Mathf.Clamp(x, Xmin, Xmax);
            y = Mathf.Clamp(y, Ymin, Ymax);
            transform.localScale = new Vector3(x, y, 1);
            transform.position = new Vector3(0, y / 2, transform.position.z);

        }
        if (Input.GetMouseButtonUp(0))
        {
            basma_aktif_mi = true;
        }
    }
    private void GhostAyarla()
    {
        if (ghost_pos.gameObject == null)
        {
            return;
        }
        ghost.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        if (x <= ghost_size.x && y <= ghost_size.y)
        {
            ghostMaterial.color = pozitifRenk;
            ghost.transform.position = new Vector3(0, transform.localScale.y / 2, ghost_pos.transform.position.z);

        }
        else
        {
            ghostMaterial.color = negetifRenk;
            ghost.transform.position = new Vector3(0, transform.localScale.y / 2, ghost_pos.transform.position.z - 1);
        }

    }

    //----------------- eventler--------------------
    private void Eventler_engeleGirdi(float ymax, float xmax)
    {
        ghost.GetComponent<MeshRenderer>().enabled = false;
        if (x <= xmax && y <= ymax)
        {
            this.Xmax = xmax;
            this.Ymax = ymax;
        }
        else
        {
            game_state = gameState.gameOver;
            Eventler.ONOyunBitti();
        }

    }
    private void engeligecti_Engeligecti()
    {

        Xmin = 0.3f;
        Xmax = 2f;
        Ymax = 2f;
        Ymin = 0.3f;
    }
    private void yeniHedefYolla_YeniHedef(YeniEngelArgs obj)
    {
        ghost.GetComponent<MeshRenderer>().enabled = true;
        ghost_pos = obj.hedef;
        ghost_size = obj.boxsize;
    }
}
