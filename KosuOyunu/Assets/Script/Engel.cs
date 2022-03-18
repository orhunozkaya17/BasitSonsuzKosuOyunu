using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Engel : MonoBehaviour
{
 [HideInInspector]  public float x, y;
    
    BoxCollider box;
    //1 sol 2 sag 3 ust
    List<GameObject> duvarlar = new List<GameObject>();
    private bool kulanildi = false;
 


    public void Engel_Olustur(float zmasefesi)
    {



        float aralik = Random.Range(0, 1.7f);
        x = aralik + 0.3f;
        y = 2 - aralik + 0.3f;
        Vector3 scal = new Vector3(2f - x / 2, y, 1);
        Vector3 pos = new Vector3(-2f + scal.x / 2, scal.y / 2, 0);

        duvarlar[0].transform.localScale = scal;
        duvarlar[0].transform.localPosition = pos;



        pos = new Vector3(2f - scal.x / 2, scal.y / 2, 0);

        duvarlar[1].transform.localScale = scal;
        duvarlar[1].transform.localPosition = pos;

        scal = new Vector3(4f, 1f, 1);
        pos = new Vector3(0, y + 0.5f, 0);

        duvarlar[2].transform.localScale = scal;
        duvarlar[2].transform.localPosition = pos;

        boxKolliderTekrarBoyutlandir(x, y);
        box.enabled = true;
        kulanildi = false;
        this.transform.position = new Vector3(0, 0, zmasefesi);
    }
    public void Duvar_Olustur(Material engel_materail)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject duvar = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //duvar metareil
            duvar.GetComponent<Renderer>().material = engel_materail;

            duvar.transform.parent = this.transform;
            duvarlar.Add(duvar);
        }


        box = gameObject.AddComponent<BoxCollider>();
        box.size = new Vector3(1, 1, 1f);
        box.isTrigger = true;

    }


    public void boxKolliderTekrarBoyutlandir(float x, float y)
    {
        box.size = new Vector3(x, y, 1.1f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && kulanildi==false)
        { 
            Eventler.engelGirdi(y, x);
            kulanildi = true;
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Eventler.EngelGecildi();
        }
    }

}
