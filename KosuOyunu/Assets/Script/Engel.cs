using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engel : MonoBehaviour
{
    float x, y;
  static  int GecilenAdet = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Collider_olustur(float x, float y)
    {
        this.x = x;
        this.y = y;
        BoxCollider box = gameObject.AddComponent<BoxCollider>();
        box.size = new Vector3(x, y, 1f);
        box.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Boyutlandirma b = other.GetComponent<Boyutlandirma>();
            if (b.x <= x && b.y <= y)
            {
                GameObject.FindGameObjectWithTag("Engel").GetComponent<EngelOlustur>().Engel_Olustur();
                GecilenAdet++;
                GameObject.Find("Text_Adet").GetComponent<Text>().text = GecilenAdet.ToString();
                Destroy(gameObject, 1f);
            }
            else
            {
                Debug.Log("Game over");
            }
        }
    }
}
