using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlustur : MonoBehaviour
{
    const float min = 0.3f;
    const float max = 2f;
    public Material engel_materail;

    float mesafe = 10f;
    int sayac = 0;
    private void Start()
    {
        Engel_Olustur();
        Engel_Olustur();
        Engel_Olustur();
    }
    public void Engel_Olustur()
    {
        GameObject Engel_Objesi = new GameObject("Engel");
       
        Engel_Objesi.transform.position = new Vector3(0, 0,mesafe*sayac+5);
        float aralik = Random.Range(0, 1.7f);
        float x = aralik + 0.3f;
        float y = 2 - aralik + 0.3f;
        Vector3 scal = new Vector3(2f - x / 2, y, 1);
        Vector3 pos = new Vector3(-2f + scal.x / 2, scal.y / 2, 0);

        Engel engel = Engel_Objesi.AddComponent<Engel>();
        engel.Collider_olustur(x, y);
        Duvar_Olustur(scal, pos, Engel_Objesi.transform);
        
        pos = new Vector3(2f - scal.x / 2, scal.y / 2, 0);
        Duvar_Olustur(scal, pos, Engel_Objesi.transform);
        scal = new Vector3(4f, 1f, 1);
        pos = new Vector3(0, y + 0.5f, 0);
        Duvar_Olustur(scal, pos, Engel_Objesi.transform);
        sayac++;
    }
    public void Duvar_Olustur(Vector3 buyukluk, Vector3 konum, Transform parent)
    {
        GameObject duvar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //duvar metareil
        duvar.GetComponent<Renderer>().material = engel_materail;
        duvar.transform.localScale = buyukluk;
        duvar.transform.parent = parent;
        duvar.transform.localPosition = konum;
 

    }
}
