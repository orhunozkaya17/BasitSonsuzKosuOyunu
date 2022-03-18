using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haraket : MonoBehaviour
{
    float hiz = 3f;
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, 1f)*Time.deltaTime* hiz;
    }
}
