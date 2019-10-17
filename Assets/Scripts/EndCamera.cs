using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamera : MonoBehaviour
{
    Camera m_MainCamera;
    public Camera m_Camera2;
    public bool pos1 = true; 
    public bool pos2 = false; 



    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        m_Camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        } 
        else if(pos2 == true)
        {
            m_Camera2.enabled = false;
        }
    }
}
