using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float tierdness;

    //public float ;


//jump
    public bool jumpFlag;

    public Vector3 velocity;
    public float startVel;
    Rigidbody rb;
    AudioSource source;
    Vector3 defPos;
    bool onFloor;
    public float jumpSpd;
    public float grav = .01f;
    public float xAccel;
    public float xMaxSpd;
    public float floorFriction;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //  if (Input.GetKey(KeyCode.Space))
        // {
        //     jumpFlag = true;

        // }

           if (Input.GetKeyDown(KeyCode.Space) && jumpFlag)
        {
            rb.AddForce(new Vector3(0f, 3f, 0f), ForceMode.Impulse);
            jumpFlag = false;
        }
    }

    void OnCollisionStay(){
        jumpFlag = true;
    }

    void FixedUpdate()
    {
        //Jump stuff
        // BoxCollider box = GetComponent<BoxCollider>();
        // Vector3 myPos = transform.position;
        // Vector3 leftPoint = myPos + (Vector3.left* (box.size.x /2f));
        // RaycastHit ray = Physics.Raycast(leftPoint,Vector3.down, (box.size.y/2f)+ 0.1f, LayerMask.GetMask("Floor"));
        // Vector3 rightPoint = myPos + (Vector3.right* (box.size.x /2f));
        // RaycastHit ray2 = Physics.Raycast(rightPoint, Vector3.down, (box.size.y/2f)+ 0.1f, LayerMask.GetMask("Floor"));

        // if (ray || ray2)
        //     onFloor = true;
        // else {
        //     onFloor = false;
        //     velocity.y -= grav;
        // }


        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(moveSpeed, 0, 0 ));
      
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(-moveSpeed, 0,0  ));

        }

     

       

    }
}
