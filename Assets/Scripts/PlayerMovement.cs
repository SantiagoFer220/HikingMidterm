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

    
    //VELOCITY STUFF
    // public Vector3 velocity;
    // public float startVel;

    // AudioSource source;
   
    // public float grav = .01f;
    // public float xAccel;
    // public float xMaxSpd;
    // public float floorFriction;
    // public float maxJump;


    //FLOOR CHECK
    public bool onFloor;
    public float jumpSpd;
    public Vector3 newPos; 
    public Vector3 changePos;
    public float lerpPos; 
     Vector3 defPos;
    Rigidbody rb;

    public GameObject legTwo; 
    public float MaxDist;
    public float upScale;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x <= legTwo.transform.position.x + 2f){
            if ( onFloor == true ||  jumpFlag == true && !Input.GetKey(KeyCode.E)){
                if (Input.GetKey(KeyCode.Q))
                {
                this.transform.position = Vector3.Lerp(defPos,newPos,lerpPos);
                newPos.x = newPos.x + 0.1f;
                

                }
            }
        }     
    }

    void OnCollisionEnter(){
    newPos = transform.position + (Vector3.up * upScale); 
    }
    void OnCollisionStay(){
        jumpFlag = true;
        
    }

    void FixedUpdate()
    {
        //Jump stuff
        BoxCollider box = GetComponent<BoxCollider>();
        Vector3 myPos = this.transform.position;

        Ray rayLeft = new Ray (myPos + (Vector3.left) * (box.size.x /(2.1f)), Vector3.down);
        Ray rayRight = new Ray (myPos + (Vector3.right) * (box.size.x /2.1f), Vector3.down);

        Debug.DrawRay(myPos + (Vector3.left) * ((box.size.x) /2.5f), Vector3.down, Color.cyan, maxDist);
        Debug.DrawRay(myPos + (Vector3.right) * (box.size.x /(2.5f)), Vector3.down, Color.cyan, maxDist);


        RaycastHit ray = new RaycastHit();
        RaycastHit ray2 = new RaycastHit();


        if ( Physics.Raycast(rayLeft, out ray, 0.5f)|| Physics.Raycast(rayRight, out ray2, 0.5f))
        {
            Debug.Log("ground");
            onFloor = true;
        }else{
            onFloor= false; 
           
        }

   

        if (Input.GetKey(KeyCode.D)) {

            this.transform.position = Vector3.Lerp(defPos,newPos,lerpPos);
        }
        if (Input.GetKey(KeyCode.A)) {

            
        }

        
     

       

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
