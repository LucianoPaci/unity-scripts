﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVR_Interaction : MonoBehaviour
{

    public Image img;
    public UnityEvent GVRClick;
    bool gvrStatus;

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus && Input.GetKeyDown("joystick button 4"))
        {
            GVRClick.Invoke();
        }
    }


    public void GvrOn()
    {
        gvrStatus = true;
    }
    public void GvrOff()
    {
        gvrStatus = false;
    }
}
