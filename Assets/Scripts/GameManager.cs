using System.Collections;
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

    public float slowFactor;

    public Image endScreen; 

    public Color tranparent;
    public Color black;
    public KeyCode Eat;
    public GameObject StartScreen;
    public GameObject RestartText;

    // Start is called before the first frame update
    void Start()
    {
        img.fillAmount = 0.5f;
        targetAmount = img.fillAmount;
        RestartText.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
    if (img!= null){
        img.color  = gradient.Evaluate( img.fillAmount);
        img.fillAmount = Mathf.Lerp(img.fillAmount, targetAmount, speed * Time.deltaTime);

        if (Mathf.Approximately(img.fillAmount, targetAmount)){
            img.fillAmount = targetAmount;
        }
        
        targetAmount -= Time.deltaTime/slowFactor;


        if (targetAmount <= 0 ){
            endScreen.color = Color.Lerp(tranparent,black,1f);
            RestartText.gameObject.SetActive(true);
            Debug.Log("fade");
        }
    }   
    if (Input.GetKey(Eat))
                {
                targetAmount = img.fillAmount + increment;
                }
    if (Input.GetKey(KeyCode.Space)){
        StartScreen.gameObject.SetActive(false);
    }

    }
}
