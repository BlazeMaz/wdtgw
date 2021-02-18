using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public ObjectMover movingObject;
    private Color red = new Color(0.976f, 0.290f, 0.372f);
    private Color green = new Color(0.556f, 1f, 0.439f);

    private void OnTriggerEnter(Collider other)
    {
        movingObject.SetActive(true);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        FindObjectOfType<AudioManager>().Play("click");
    }

    private void OnTriggerExit(Collider other)
    {
        movingObject.SetActive(false);
        gameObject.GetComponent<Renderer>().material.color = red;
        FindObjectOfType<AudioManager>().Play("clickOff");
    }
}