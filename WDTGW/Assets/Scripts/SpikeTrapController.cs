using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    public GameObject spikes;
    public float downTime, upTime, startTime;

    private float time;
    private bool active;
    private BoxCollider boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        spikes.SetActive(false);
        boxCollider.enabled = false;
        time = startTime;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (!active && time >= downTime)
        {
            time = 0;
            spikes.SetActive(true);
            boxCollider.enabled = true;
            active = true;
        }
        
        if (active && time >= upTime)
        {
            // to można spiąć w jedną metode
            time = 0;
            spikes.SetActive(false);
            boxCollider.enabled = false;
            active = false;
        }
    }
}
