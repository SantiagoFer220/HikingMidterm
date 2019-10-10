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

    float maxDist = 0.4f;

    public Vector3 velocity;
    public float startVel;
    Rigidbody rb;
    AudioSource source;
    Vector3 defPos;
    public bool onFloor;
    public float jumpSpd;
    public float grav = .01f;
    public float xAccel;
    public float xMaxSpd;
    public float floorFriction;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.Space))
        {
            jumpFlag = true;

        }
           
    }

    void OnCollisionStay(){
        jumpFlag = true;
    }

    void FixedUpdate()
    {
        //Jump stuff
        BoxCollider box = GetComponent<BoxCollider>();
        Vector3 myPos = this.transform.position;

        Ray rayLeft = new Ray (myPos + (Vector3.left) * (box.size.x /2f), Vector3.down);
        Ray rayRight = new Ray (myPos + (Vector3.right) * (box.size.x /2f), Vector3.down);

        Debug.DrawRay(myPos + (Vector3.left) * (box.size.x /2f), Vector3.down, Color.cyan, maxDist);
        Debug.DrawRay(myPos + (Vector3.right) * (box.size.x /2f), Vector3.down, Color.cyan, maxDist);


        RaycastHit ray = new RaycastHit();
        RaycastHit ray2 = new RaycastHit();


        if ( Physics.Raycast(rayLeft, out ray, 0.5f)|| Physics.Raycast(rayRight, out ray2, 0.5f))
        {
            Debug.Log("ground");
            onFloor = true;
        }else{
            onFloor= false; 
            velocity.y -= grav;
        }

      
       
        if ( onFloor == true && jumpFlag == true){

            if (Input.GetKey(KeyCode.Space)){
                jumpFlag = false;
                velocity += Vector3.up * jumpSpd;
            }
        }

   

        if (Input.GetKey(KeyCode.D)) {
            velocity.x += xAccel;
        }
        if (Input.GetKey(KeyCode.A)) {
            velocity.x -= xAccel;
        }

        if (onFloor && Mathf.Abs(velocity.x) > 0 && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
            if (Mathf.Abs(velocity.x) < floorFriction)
                velocity.x = 0;
            else
                velocity.x -= Mathf.Sign(velocity.x) * floorFriction;
        }

        velocity.x = Mathf.Max(-xMaxSpd, Mathf.Min(velocity.x, xMaxSpd));

        if (velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            velocity.y = 0;

        if (jumpFlag) {
            jumpFlag = false;
            if (onFloor) {
                velocity += Vector3.up * jumpSpd;
            }
        }



        rb.MovePosition(myPos + velocity);

     

       

    }
}


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

        //movement mods
