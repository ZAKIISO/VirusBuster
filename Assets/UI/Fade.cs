﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float alfa;
    float speed = 0.03f;
    float red, green, blue;

    void Start()
    { 
        alfa = 0;

        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
    }
}