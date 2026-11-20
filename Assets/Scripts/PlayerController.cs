using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public ColliderDetection cd;
    Vector2 playerInput;

    public Rigidbody2D rg2d;
    public enum FacingDirection
    {
        left, right
    }

    FacingDirection fd;


    public Animator anim;

    public bool isWalking;

    public bool onGround;

    public bool direction;

    public Vector3 detecetion;

    public float pY;

    void Start()
    {
        
    }

    void Update()
    {

        

       
      
        playerInput = new Vector2();

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput = new Vector2(-3, pY);
            isWalking = true;
            direction = true;

        }

       else if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput = new Vector2(3, pY);
            isWalking = true;
            direction = false;

        }

        else if(!Keyboard.current.leftArrowKey.isPressed && !Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput = new Vector2(0, pY);
            isWalking = false;

        }

        if(cd.isGround)
        {
            pY = 0;
        }
        else if(!cd.isGround)
        {
            pY = -1;
        }
        
        {
            Debug.Log("hmmm");
        }
            


        Debug.Log(playerInput);

        if (Physics.Raycast(transform.position, Vector3.Normalize(Vector3.down), 3f))
        {
            Debug.Log("erm");
            onGround = false;
        }

        else if (!Physics.Raycast(transform.position, Vector3.Normalize(Vector3.down), 3f))
        {
            onGround = true;
        }


    }

    private void FixedUpdate()
    {
        MovementUpdate(playerInput);
  

    }









    private void MovementUpdate(Vector2 playerInput)
    {

        rg2d.linearVelocity = playerInput;
        if (playerInput.x == 0)
        {
            rg2d.linearVelocity = new Vector2(0, 0);

            
        }

        if (!cd.isGround)
        {
           

            if (playerInput.x == 0)
            {
                rg2d.linearVelocity = new Vector2(0, -1);


            }
        }


    }

    public bool IsWalking()
    {
        
            return isWalking;
        
    
    }
    public bool IsGrounded()
    {
      
        return cd.isGround;
        
    }

    public FacingDirection GetFacingDirection()
    {
       
        if (direction == true)
        {
            fd = FacingDirection.left;
        }

        if (direction == false)
        {
            fd = FacingDirection.right;
        }

        return fd;


      


    }

  
    



}
