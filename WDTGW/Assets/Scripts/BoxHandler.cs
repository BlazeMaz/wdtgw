using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHandler : MonoBehaviour
{
    private Vector3 boxPosition;
    private Vector3 moV = new Vector3(0, 1, 0);

    [SerializeField] private float waitSeconds = 2.0f;

    private void Start()
    {
        boxPosition = transform.position + moV;
    }

    private void Update()
    {
        if (transform.position.y < -3)
        {
            gameObject.SetActive(false);
            Invoke(nameof(RespawnBox), waitSeconds);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Box") && other.CompareTag("Saw"))
        {
            gameObject.SetActive(false);
            Invoke(nameof(RespawnBox), waitSeconds);
        }
    }

    void RespawnBox()
    {
        transform.position = boxPosition;
        gameObject.SetActive(true);
    }
}