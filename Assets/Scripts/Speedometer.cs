using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    void Start()
    {
    }


    void Update()
    {
    }

    // Retorna un Vector3 para aplicar Speed en sentido contrario á subida
    public Vector3 GetVelocity()
    {
        return Vector3.down;
    }
}
