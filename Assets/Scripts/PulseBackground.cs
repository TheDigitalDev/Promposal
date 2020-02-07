using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBackground : MonoBehaviour
{

    public Color minColorRGB;
    public Color maxColorRGB;
    
    public Camera camera;

    public float rate = 1f;
    public void Update()
    {
        Color c = Color.Lerp(minColorRGB, maxColorRGB, Mathf.PingPong(Time.time, 1f));
        camera.backgroundColor = c;
    }
}