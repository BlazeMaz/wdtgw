using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, 30 * Time.deltaTime);
    }
}