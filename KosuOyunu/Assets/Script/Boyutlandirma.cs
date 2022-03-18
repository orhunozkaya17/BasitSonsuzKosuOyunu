using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyutlandirma : MonoBehaviour
{

    const float min = 0.3f;
    const float max = 2f;
    [HideInInspector] public float x, y;
    Vector3 sonKonum;
    bool basma_aktif_mi = true;
    private void Start()
    {
        x = transform.localScale.x;

        y = transform.localScale.y;
    }
    private void Update()
    {
        Ayarla();
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
            x = Mathf.Clamp(x, min, max);
            y = Mathf.Clamp(y, min, max);
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
            x = Mathf.Clamp(x, min, max);
            y = Mathf.Clamp(y, min, max);
            transform.localScale = new Vector3(x, y, 1);
            transform.position = new Vector3(0, y / 2, transform.position.z);

        }
        if (Input.GetMouseButtonUp(0))
        {
            basma_aktif_mi = true;
        }
    }
}
