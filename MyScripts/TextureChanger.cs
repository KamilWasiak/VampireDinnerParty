﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    public RandomTexture randomTexture2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyPress();
    }
    
    void CheckKeyPress()
    {
            if (Input.GetKeyDown(KeyCode.Y))
        {
            randomTexture2.GetRandomTexture();
        }
    }
}
