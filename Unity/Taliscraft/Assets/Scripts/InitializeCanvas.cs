﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitializeCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
