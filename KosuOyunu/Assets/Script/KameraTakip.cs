using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 fark;
    float y;

    private void Start()
    {
        y = transform.position.y;
        fark = transform.position - hedef.transform.position;

    }
    void LateUpdate()
    {
        transform.position = hedef.transform.position + fark;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
