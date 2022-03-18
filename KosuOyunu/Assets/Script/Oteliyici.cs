using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oteliyici : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cevre"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z+90f);
        }
    }
}
