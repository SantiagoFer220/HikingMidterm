using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public float moveSpeed;
    // public float turnSpeed;
    // public float tierdness;

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
   // public float jumpSpd;
    public Vector3 newPos; 
  //  public Vector3 changePos;
    public float lerpPos; 
     Vector3 defPos;
    Rigidbody rb;

   public GameObject OtherLeg;
     public float MaxDist;
    public float upScale;
    public KeyCode Walk; 
    public KeyCode OppositeLeg;
    public PlayerMovement OtherLegScript;
    public bool ThisLegUp;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defPos = transform.position;
        OtherLegScript = OtherLeg.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x <= OtherLeg.transform.position.x + 2f && jumpFlag == true){
            if ( onFloor == true ||  jumpFlag == true && !Input.GetKey(OppositeLeg) && !OtherLegScript.ThisLegUp){
                if (Input.GetKey(Walk))
                {
                Debug.Log("move");
                this.transform.position = Vector3.Lerp(defPos,newPos,(lerpPos+ Time.deltaTime/10));
                newPos.x = newPos.x + 0.1f;
                
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision){
    newPos = transform.position + (Vector3.up * upScale); 
     
    }
    void OnCollisionStay(Collision collision){
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


        if ( Physics.Raycast(rayLeft, out ray, MaxDist)|| Physics.Raycast(rayRight, out ray2, MaxDist))
        {
            Debug.Log("ground");
            onFloor = true;
            ThisLegUp = false;
        }else{
            Debug.Log("not ground");
            onFloor= false; 
            ThisLegUp = true; 
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
