﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public Image img;
    public Gradient gradient; 

    public float increment; 

    float targetAmount; 
    float speed = 5f;




    // Start is called before the first frame update
    void Start()
    {
        img.fillAmount = 0.5f;
        targetAmount = img.fillAmount;
    }

    public void OnIncrese(){
        targetAmount = img.fillAmount + increment;
    }

    public void OnDecrese(){
        targetAmount = img.fillAmount - increment;
    }

    // Update is called once per frame
    void Update()
    {
        img.color  = gradient.Evaluate( img.fillAmount);
        img.fillAmount = Mathf.Lerp(img.fillAmount, targetAmount, speed * Time.deltaTime);

        if (Mathf.Approximately(img.fillAmount, targetAmount)){
            img.fillAmount = targetAmount;
        }
    }
}