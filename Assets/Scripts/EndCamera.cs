using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement; 

public class EndCamera : MonoBehaviour
{
    public Camera m_MainCamera;
    public Camera m_Camera2;
    public Camera m_Camera3;
    public bool pos1 = true; 
    public bool pos2 = false; 
    public Image Image; 

    public Button Button1;
    public Image Food;
    public KeyCode Restart;
    public GameObject FootOne;
    public GameObject FootTwo; 
    


    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        m_Camera2.enabled = false;
        m_Camera3.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(Restart)){
                SceneManager.LoadScene("MainScene");
                m_Camera2.enabled = false;
                m_MainCamera.enabled = true;


            }
    }

    void OnTriggerEnter (Collider other){
         if(pos1 == true && other.gameObject.tag == ("Pos1"))
        {
            m_MainCamera.enabled = true;
        } 
        else if(pos1 == false)
        {
            m_MainCamera.enabled = false;
        }

        if(pos2 == false && other.gameObject.tag == ("Pos2"))
        {
            m_Camera2.enabled = true;
            Food.gameObject.SetActive(false);
            FootOne.gameObject.SetActive(false);
            FootTwo.gameObject.SetActive(false);
            
          
        } 
        else if(pos2 == true)
        {
            m_Camera2.enabled = false;


        }
       

    }
}
