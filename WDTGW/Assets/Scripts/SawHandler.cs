using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHandler : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 360*Time.deltaTime, Space.Self);
    }
}