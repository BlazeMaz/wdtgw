using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour
{
    private Vector3 positionA;
    private Vector3 positionB;
    private Vector3 nextPosition;
    private float orginalSpeed;

    [SerializeField] private float speed;
    [SerializeField] private Transform transformB;
    [SerializeField] private bool active = true;

    void Start()
    {
        positionA = transform.position;
        positionB = transformB.position;
        nextPosition = positionB;
        orginalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPosition) <= 0.1)
        {
            nextPosition = nextPosition != positionA ? positionA : positionB;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"CagedBox"))
        {
            nextPosition = nextPosition != positionA ? positionA : positionB;
        }
    }

    public void SetActive(bool bollean)
    {
        active = bollean;
    }
}